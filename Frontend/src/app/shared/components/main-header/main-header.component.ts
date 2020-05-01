import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginApiService } from '../../services/login-api.service';

@Component({
  selector: 'app-main-header',
  templateUrl: './main-header.component.html',
  styleUrls: ['./main-header.component.scss']
})
export class MainHeaderComponent implements OnInit {

  constructor(
    private router: Router,
    private loginApiService: LoginApiService
  ) { }

  ngOnInit(): void {
  }

  logout() {
    this.loginApiService.logout();
    this.router.navigate(['/login']);
  }

}
