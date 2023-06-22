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

  constructor( private riddleService: RiddlesService ) {}

  ngOnInit(): void {
    this.getRiddles();
  }

  getRiddles(): void {
    this.riddleService.getRiddles()
      .subscribe( riddles => this.riddles = riddles);
  }
}
