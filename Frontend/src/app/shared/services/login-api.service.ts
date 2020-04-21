import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginApiService {

  constructor(private http: HttpClient) { }

  login(email: string, password: string): Observable<object> {
    return this.http.post('https://localhost:44349/Login', {email, password});
  }
}
