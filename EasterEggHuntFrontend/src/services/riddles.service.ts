import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';

import { Riddle } from 'src/data/riddle';

@Injectable({
  providedIn: 'root'
})
export class RiddlesService {
  private riddlesUrl = 'http://localhost:5000/api/Riddles';

  constructor( private http: HttpClient ) { }

  // GET: Gets the riddles from the server
  getRiddles(): Observable<Riddle[]> {
    return this.http.get<Riddle[]>(this.riddlesUrl)
  }
}
