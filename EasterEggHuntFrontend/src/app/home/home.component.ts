import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router'

import { Riddle } from 'src/data/riddle';
import { RiddlesService } from 'src/services/riddles.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  private _riddles: Riddle[] = [];
  private _index: number = 0;

  protected correctStatusMessage: string = "";
  protected correctStatusVisibility: boolean = false;
  protected hintVisibility: boolean = false;
  protected currentRiddle: Riddle = {
    id: -1,
    question: "",
    answer: "",
    hint: "",
    progressCode: "",
  };
  

  constructor( private _riddleService: RiddlesService, private _router: Router ) {}

  ngOnInit(): void {
    this.getRiddles();
  }

  getRiddles(): void {
    this._riddleService.getRiddles()
      .subscribe( serverRiddles => this._riddles = serverRiddles, 
                  () => this.currentRiddle.question = "ERROR COULD NOT CONNECT TO QUESTION DATABASE", // Error case
                  () => this.currentRiddle = this._riddles[0] ); // When subscribe is done
  }

  submitAnswer( userAnswer: string ): void {
    if ( this.currentRiddle.answer.toLowerCase() == userAnswer.toLowerCase() ) {
      this.displayResponseMessage("Correct!");
      this.hintVisibility = false;
      
      // This is temporary, when you win, you should go to a win screen.
      ++this._index < this._riddles.length ? this.currentRiddle = this._riddles[this._index] : this._router.navigate(['winnerwinnerchickendinner']);
    }
    else
    {
      if ( this.correctStatusVisibility )
        return;
      this.displayResponseMessage("Incorrect!");
    }
  }

  submitProgCode( userProgCode: string ): void {
    for ( var i in this._riddles ) {
      if ( this._riddles[i].progressCode == userProgCode ) {
        this.currentRiddle = this._riddles[i];
        this._index = parseInt(i);
        
        this.displayResponseMessage("Successfully found question!");
        return;
      }
    }

    this.displayResponseMessage("Invalid Progress Code!")
  }

  displayResponseMessage(respMsg: string): void {
    this.correctStatusMessage = respMsg;
    this.correctStatusVisibility = true;
    setTimeout( 
      () => {this.correctStatusVisibility = false, this.correctStatusMessage = ""}, 2000 
    );
  }

  displayHint(): void {
    this.hintVisibility = true;
  }
}
