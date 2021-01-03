import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Coins} from '../models/coins';
import {map} from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class CoinsService {
  coins: Coins[] = [];
  result: any;

  constructor(private http: HttpClient) {
  }

  /*  this.http.get<any>('https://api.npms.io/v2/search?q=scope:angular').subscribe(data => {
    this.totalAngularPackages = data.total;
  })*/

  traerBtc(): any {
    /*  return this.http.get<any>(``)
        .subscribe(data => {
          console.log('Usuario registrado');
          this.coins = data.total;
        });*/
    console.log('estoy aqui');
    this.http.get('https://www.dolarsi.com/api/api.php?type=valoresprincipales').subscribe((res: any) => {
    console.log(res);
    });
/*    console.log('estoy aqui');
    this.http.get<any>('https://www.dolarsi.com/api/api.php?type=valoresprincipales').pipe(map( res => {
      console.log(res);
    }));*/
  }


}
