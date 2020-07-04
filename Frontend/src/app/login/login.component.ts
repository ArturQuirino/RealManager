import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginApiService } from '../shared/services/login-api.service';

export class User {
  id: number;
  username: string;
  password: string;
  firstName: string;
  lastName: string;
  token?: string;
}

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm = new FormGroup({
    email: new FormControl(''),
    password: new FormControl(''),
  });

  invalidUser = false;

  constructor(private router: Router, private loginApiService: LoginApiService) { }

  ngOnInit() {
  }

  signin(loginData: any) {
    this.loginApiService.login(loginData.email, loginData.password).subscribe(
      () => {
        this.router.navigate(['/main']);
      },
      () => this.invalidUser = true
    );
  }
}
