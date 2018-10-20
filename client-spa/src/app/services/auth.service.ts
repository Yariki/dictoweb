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

  singin(email, password): Promise<any> {
    const serviceheaders = new HttpHeaders();
    serviceheaders.append('Access-Control-Allow-Origin', '*');


    const promise = new Promise<any>((resolve, reject) => {
      this.httpClient.post(this.baseUrlSignIn,{ email: email, password: password}, {headers: serviceheaders}).subscribe(response => {
          const t = new Token()
          t.expiration = response.expiration;
          t.token = response.token;
          t.user = response.user;
          this.token = t;
          resolve(true);
      },
        error => {
          reject(error);
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
