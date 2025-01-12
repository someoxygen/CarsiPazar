import { Injectable } from '@angular/core';
import { LoginUser } from '../models/loginUser';
import { HttpClient, HttpHeaders } from '@angular/common/http';
// import { JwtHelper, tokenNotExpired } from 'angular2-jwt';
// import { JwtHelper } from 'angular-jwt';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';
import { AlertifyService } from './alertify.service';
import { RegisterUser } from '../models/registerUser';

@Injectable({
  providedIn: 'root',
})
export class AuthService {

  constructor(private httpClient: HttpClient, private router: Router, private alertifyService : AlertifyService) {}

  path = 'http://localhost:5237/api/auth/';
  userToken : any;
  decodedToken : any;
  helper = new JwtHelperService();
  TOKEN_KEY = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiYWRtaW4iOnRydWUsImlhdCI6MTUxNjIzOTAyMn0.VFb0qJ1LRg_4ujbZoRMXnVkUgiuKq5KxWqNdbKq_G9Vvz-S1zZa9LPxtHWKa64zDl2ofkT8F6jBt_K4riU-fPg";

  login(loginUser : LoginUser) {
    let headers = new HttpHeaders();
    headers = headers.append('Content-Type', 'application/json');
    this.httpClient
      .post<string>(this.path + 'login', loginUser, { headers: headers })
      .subscribe(data => {
        this.saveToken(data);
        this.userToken = data;
        this.decodedToken = this.helper.decodeToken(data);
        this.alertifyService.success("Logged in successfully.");
        //this.router.navigateByUrl('/note');
      });
  }

  register(registerUser : RegisterUser){
    let headers = new HttpHeaders();
    headers = headers.append('Content-Type', 'application/json');
    this.httpClient
    .post<any>(this.path + 'register', registerUser, { headers: headers })
    .subscribe(data => {
      this.alertifyService.success("User created successfully.");
      this.alertifyService.success("Now you need to login.");
    });
  }

  saveToken(token : any){
    localStorage.setItem(this.TOKEN_KEY, token);
  }

  logOut(){
    localStorage.removeItem(this.TOKEN_KEY);
    this.alertifyService.success("Logged out successfully.");
  }

  loggedIn(){
    return this.helper.isTokenExpired(this.TOKEN_KEY); 
  }

  get token(){
    return localStorage.getItem(this.TOKEN_KEY); 
  }

  getCurrentUserId(){
    return this.helper.decodeToken(localStorage.getItem(this.TOKEN_KEY) || '{}').nameid;
  }

  // getCurrentUserId(){
  //   return this.decodedToken?.nameid;
  // }
}
