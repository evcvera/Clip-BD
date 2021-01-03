import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {environment} from '../../environments/environment';
import {map} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class RegistrationService {

  constructor(private http: HttpClient) {
  }

  registration(newUser): Observable<any> {
    return this.http.post<any>(`${environment.apiUrl}/api/registration/newuser`, newUser)
      .pipe(map(user => {
        return user;
      }));
  }
}
