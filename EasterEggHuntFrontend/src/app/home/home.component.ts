import { Component, OnInit } from '@angular/core';

import { Riddle } from 'src/data/riddle';
import { RiddlesService } from 'src/services/riddles.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  riddles: Riddle[] = [];
  index: number = 0;
  currentRiddle: string = "";
  currentHint: string = "";
  correctStatusMessage: string = "";
  correctStatusVisibility: boolean = false;
  hintVisibility: boolean = false;

  constructor( private riddleService: RiddlesService ) {}

  ngOnInit(): void {
    this.getRiddles();
  }

  getRiddles(): void {
    this.riddleService.getRiddles()
      .subscribe( serverRiddles => this.riddles = serverRiddles, 
                  () => this.currentRiddle = "ERROR COULD NOT CONNECT TO QUESTION DATABASE", // Error case
                  () => this.currentRiddle = this.riddles[0].question); // When subscribe is done
  }

  submitAnswer( userAnswer: string ): void {
    if ( this.riddles[this.index].answer.toLowerCase() == userAnswer.toLowerCase() ) {
      this.displayResponseMessage("Correct!");
      this.hintVisibility = false;
      
      // This is temporary, when you win, you should go to a win screen.
      ++this.index < this.riddles.length ? this.currentRiddle = this.riddles[this.index].question : this.currentRiddle = "You Win!";
    }
    else
    {
      if (this.correctStatusVisibility)
        return;
      this.displayResponseMessage("Incorrect!");
    }
  }

  displayResponseMessage(respMsg: string): void {
    this.correctStatusMessage = respMsg;
    this.correctStatusVisibility = true;
    setTimeout( 
      () => {this.correctStatusVisibility = false, this.correctStatusMessage = ""}, 2000 
    );
  }

  displayHint(): void {
    this.currentHint = this.riddles[this.index].hint;
    this.hintVisibility = true;
  }
}
