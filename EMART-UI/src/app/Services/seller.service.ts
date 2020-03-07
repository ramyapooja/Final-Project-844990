import { Injectable } from '@angular/core';
import {HttpClient,HttpHeaders } from "@angular/common/http";
import {Observable} from "Rxjs";
import { Seller } from '../Models/seller';
import { Category } from '../Models/category';
const Requestheaders={headers:new HttpHeaders({
  'Content-Type':'application/json',
  'Authorization':'Bearer'+localStorage.getItem('token')
})}
@Injectable({
  providedIn: 'root'
})
export class SellerService {

  url:string='http://localhost:61276/Seller/'
  constructor(private http:HttpClient) { }
  public ViewProfile(id:string):Observable<any>{
    return this.http.get<Seller>(this.url+'ViewProfile/'+id,Requestheaders);
  }
  public EditProfile(seller:Seller):Observable<any>
  {
    return this.http.put<any>(this.url+'EditProfile',JSON.stringify(seller),Requestheaders);
  }
  
}
