import { Injectable } from '@angular/core';
import {HttpClient,HttpHeaders } from "@angular/common/http";
import {Observable} from "Rxjs";
import { Items } from '../Models/items';

const Requestheaders={headers:new HttpHeaders({
  'Content-Type':'application/json',
})}
@Injectable({
  providedIn: 'root'
})
export class BuyerService {
  url:string="http://localhost:61276/Buyer/";

  constructor(private http:HttpClient) {
    
   }
   public SearchItems(name:string):Observable<Items[]>
  {
    return this.http.get<Items[]>(this.url+'SearchItem/'+name,Requestheaders);
  }

}
