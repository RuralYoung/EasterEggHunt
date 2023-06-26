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

  constructor( private riddleService: RiddlesService ) {}

  ngOnInit(): void {
    this.getRiddles();
  }

  getRiddles(): void {
    this.riddleService.getRiddles()
      .subscribe( serverRiddles => this.riddles = serverRiddles, 
                  () => this.currentRiddle = "ERROR COULD NOT CONNECT TO QUESTION DATABASE", 
                  () => this.currentRiddle = this.riddles[0].question);
  }

  submitAnswer( userAnswer: string ): void {
    console.log(userAnswer);
  }

  /*nextButton(): void {
    if ( this.index < this.riddles.length )
    {
      this.currentRiddle = this.riddles[this.index++]?.question;
    }
    else {
      this.index = 0;
      this.currentRiddle = this.riddles[this.index++]?.question;
    }
  }*/
}
