import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LoginComponent } from './login.component';
import { Router } from '@angular/router';
import { LoginApiService } from '../shared/services/login-api.service';
import { Observable, throwError, of } from 'rxjs';
import { ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '../shared/modules/material.module';

let routerMock: Partial<Router>;

let loginApiServiceMock: Partial<LoginApiService>;

describe('LoginComponent', () => {
  let component: LoginComponent;
  let fixture: ComponentFixture<LoginComponent>;

  beforeEach(() => {

    loginApiServiceMock = {
      login: (email, password) => of(true)
    };

    routerMock = {
      navigate: () => null
    };

    TestBed.configureTestingModule({
      declarations: [LoginComponent],
      imports: [ReactiveFormsModule, MaterialModule],
      providers: [
        { provide: Router, useValue: routerMock },
        { provide: LoginApiService, useValue: loginApiServiceMock }
      ]
    })
    .compileComponents();

  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should set invalidUser when user/password invalid', () => {
    const loginApiServiceMockTest = fixture.debugElement.injector.get(LoginApiService);
    spyOn(loginApiServiceMockTest, 'login').and.callFake(() => {
      return throwError(new Error('fake error'));
    });

    component.signin({email: 'test', password: 'test'});
    expect(component.usarioSenhaInvalido).toBeTruthy();
  });

  it('should not set invalidUser when user/password valid', () => {
    component.signin({email: 'test', password: 'test'});
    expect(component.usarioSenhaInvalido).toBeFalsy();
  });
});
