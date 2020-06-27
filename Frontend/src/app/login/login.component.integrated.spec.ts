import { async, ComponentFixture, TestBed, flush, fakeAsync, tick } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

import { LoginComponent } from './login.component';
import { Router } from '@angular/router';
import { LoginApiService } from '../shared/services/login-api.service';
import { Observable, throwError, of } from 'rxjs';
import { ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '../shared/modules/material.module';
import { HttpClientModule } from '@angular/common/http';

let routerMock: Partial<Router>;

describe('Integrated - LoginComponent', () => {
  let component: LoginComponent;
  let fixture: ComponentFixture<LoginComponent>;

  let httpClient: HttpClient;
  let httpTestingController: HttpTestingController;

  beforeEach(async(() => {

    routerMock = {
      navigate: () => null
    };

    TestBed.configureTestingModule({
      declarations: [LoginComponent],
      imports: [ReactiveFormsModule, MaterialModule, HttpClientModule, HttpClientTestingModule ],
      providers: [
        { provide: Router, useValue: routerMock },
      ]
    })
    .compileComponents();

    httpClient = TestBed.inject(HttpClient);
    httpTestingController = TestBed.inject(HttpTestingController);
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should set invalidUser when user/password invalid', fakeAsync(() => {
    const testData = {email: 'test', password: 'test'};

    component.signin(testData);

    const req = httpTestingController.expectOne('https://localhost:5001/Login');

    req.flush( '401 error', { status: 401, statusText: 'Not Authorized' });

    expect(component.invalidUser).toBeTruthy();
  }));

  it('should not set invalidUser when user/password valid', async (() => {
    const testData = {email: 'test', password: 'test'};

    component.signin(testData);

    const req = httpTestingController.expectOne('https://localhost:5001/Login');

    req.flush( 'valid user', { status: 200, statusText: 'Authorized' });

    expect(component.invalidUser).toBeFalsy();
  }));
});

