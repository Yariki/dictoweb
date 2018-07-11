import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders, HttpRequest} from '@angular/common/http';
import {Token} from '../models/token';
import {User} from '../models/user';

@Injectable()
export class AuthService {

  private token: Token;

  private baseUrlSignUp = 'http://localhost:5000/api/login/signup';
  private baseUrlSignIn = 'http://localhost:5000/api/login/token';

  constructor(private httpClient: HttpClient) {
  }

  singin(email, password): Promise<boolean> {
    const serviceheaders = new HttpHeaders();
    serviceheaders.append('Access-Control-Allow-Origin', '*');


    const promise = new Promise<boolean>((resolve, reject) => {
      this.httpClient.post<Token>(this.baseUrlSignIn,{ email: email, password: password}, {headers: serviceheaders}).subscribe(response => {
        if (response != null) {
          this.token = response;
          resolve(true);
        } else {
          reject(false);
        }
      });
    });
    return promise;
  }


  singup(user: User): Promise<boolean> {
    const serviceheaders = new HttpHeaders();
    serviceheaders.append('Access-Control-Allow-Origin', '*');
    const promise = new Promise<boolean>((resolve, reject) => {
      this.httpClient.post<Token>(this.baseUrlSignUp, user, {headers: serviceheaders}).subscribe(response => {
        if (response != null) {
          resolve(true);
        } else {
          reject(false);
        }
      });
    });
    return promise;

  }

  isAuthenticated(): boolean {
    return this.token != null && this.token.token != null;
  }

  getToken(): string {
    return this.token.token;
  }

  getName(): string {
    return this.token.user;
  }

}