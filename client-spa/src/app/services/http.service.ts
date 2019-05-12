import {Injectable} from '@angular/core';
import {AuthService} from './auth.service';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {reject} from 'q';

@Injectable()
export class HttpService {

  private baseUrl = 'http://localhost:5000/api/';

  constructor(private httpClient: HttpClient, private authService: AuthService) {

  }

  get<T>(action: string, data: any): Promise<T> {

    const promise = new Promise<T>((resolve) => {

      const httpOptions = {
        headers: new HttpHeaders({
          'Access-Control-Allow-Origin': '*',
          'Authorization': 'Bearer ' + this.authService.getToken()
        }),
        params: data
      };
      this.httpClient.get<T>(this.baseUrl + action, httpOptions ).subscribe(response => {
        resolve(response);
      });
    });
    return promise;
  }

  post<T>(action: string, data: any): Promise<T> {

    const promise = new Promise<T>(resolve => {
      const httpOptions = {
        headers: new HttpHeaders({
          'Access-Control-Allow-Origin': '*',
          'Authorization': 'Bearer ' + this.authService.getToken()
        })
      };

      this.httpClient.post<T>(this.baseUrl + action, data, httpOptions).subscribe(response => {
        resolve(response);
      });
    });
    return promise;
  }

  delete<T>(action: string): Promise<T> {
    const promise = new Promise<T>(resolve => {
      const httpOptions = {
        headers: new HttpHeaders({
          'Access-Control-Allow-Origin': '*',
          'Authorization': 'Bearer ' + this.authService.getToken()
        })
      };
      this.httpClient.delete<T>(this.baseUrl + action, httpOptions).subscribe(response => {
        resolve(response);
      });
    });
    return promise;
  }

}
