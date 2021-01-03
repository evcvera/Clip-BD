import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {environment} from '../../environments/environment';
import {map} from 'rxjs/operators';
import {ChangeUserPassword} from '../models/User/change-user-password';

@Injectable({
  providedIn: 'root'
})
export class EditUserService {


  constructor(private http: HttpClient) {
  }

  /*  changePassword(email): Observable<any> {
      console.log('hola');
      return this.http.post<any>(`${environment.apiUrl}/api/UserAccount`, email )
        .pipe(map(user => {
          return user;
        }));
    }*/


  changePassword(changeUserPassword: ChangeUserPassword): Observable<any> {
    return this.http.post<any>(`${environment.apiUrl}/api/useraccount/changepassword`, changeUserPassword)
      .pipe(map(resp => {
        return resp;
      }));
  }

}
