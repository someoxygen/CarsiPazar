import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
// import { City } from '../models/city';
// import { Photo } from '../models/photo';
import { AlertifyService } from './alertify.service';
import { Router } from '@angular/router';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private httpClient: HttpClient,
    private alertifyService : AlertifyService,
    private router : Router
  ) {}
  path = 'http://localhost:5103/api/';

  getUserById(userId : number): Observable<User>{
    return this.httpClient.get<User>(this.path + "Users/getUserById/?id=" + userId);
  }
}
