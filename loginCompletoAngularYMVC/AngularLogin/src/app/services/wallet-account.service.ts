import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {BehaviorSubject, Observable} from 'rxjs';
import {environment} from '../../environments/environment';
import {map} from 'rxjs/operators';
import {NewAccount} from '../models/WalletAccount/new-account';
import {AuthenticationService} from './authentication.service';
import {UserNoToken} from '../models/user-no-token';


const initialData: NewAccount[] = [];

@Injectable({
  providedIn: 'root'
})
export class WalletAccountService {

  userNoToken: UserNoToken = new UserNoToken();

  newAccount: NewAccount = new NewAccount();

  WalletAccount$: BehaviorSubject<NewAccount[]> =  new BehaviorSubject<NewAccount[]>(initialData);
  currentWalletAccount: Observable<NewAccount[]>;


  constructor(private http: HttpClient,
              private authenticationService: AuthenticationService) {
    this.userNoToken = this.authenticationService.currentUserValue.loginUser;
  }

  newWalletAccount(newAccount: NewAccount): Observable<any> {
    this.WalletAccount$.unsubscribe();
    return this.http.post<any>(`${environment.apiUrl}/api/walletaccount/newwallet`, newAccount)
      .pipe(map(resp => {
        this.getWalletAccount();
        return resp;
      }));
  }

  getWalletAccount(): any {
    return this.http.post<any>(`${environment.apiUrl}/api/walletaccount/getwallet`, this.userNoToken).subscribe(
      (data: NewAccount[]) => {
        console.log(data);
        this.WalletAccount$.next(data);
      },
      error => {
        console.log('Error');
      });
  }


  /*  getWalletAccount(): Observable<any> {
      return this.http.post<any>(`${environment.apiUrl}/api/walletaccount/getwallet`, this.userNoToken)
        .pipe(map((resp) => {
          console.log(resp);
          return resp;
        }));
    }

    getWallet(): any {
      this.getWalletAccount().subscribe(
        (data: NewAccount[]) => {
          if (data !== null) {
            console.log('true');
          } else {
            console.log('false');
          }
        },
        error => {
          console.log('Error');
        });
    }*/
}
