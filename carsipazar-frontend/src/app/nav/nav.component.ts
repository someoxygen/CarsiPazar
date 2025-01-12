import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
})
export class NavComponent implements OnInit {

  constructor(private authService : AuthService, private router : Router) { }
  
  loginUser : any = {};
  isAuthenticated = false;
  operationName = 'add';
  ngOnInit() {
  }

  login(){
    this.authService.login(this.loginUser);
    this.isAuthenticated = true;
  }

  logOut(){
    this.authService.logOut();
    this.isAuthenticated = false;
    this.router.navigateByUrl('/register');
  }
}
