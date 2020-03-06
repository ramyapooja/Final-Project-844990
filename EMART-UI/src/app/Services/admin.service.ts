import { Injectable } from '@angular/core';
import {HttpClient,HttpHeaders } from "@angular/common/http";
import {Observable} from "Rxjs";
import { Category } from '../Models/category';
import { SubCategory } from '../Models/sub-category';

const Requestheaders={headers:new HttpHeaders({
  'Content-Type':'application/json',
  'Authorization':'Bearer'+localStorage.getItem('token')
})}
@Injectable({
  providedIn: 'root'
})
export class AdminService {

  url:string="http://localhost:61276/Admin/";
  constructor(private http:HttpClient) { }

  public AddCategory(cat:Category):Observable<any>
  {
    return this.http.post(this.url+'AddCategory',cat,Requestheaders);
  }
  public AddSubcategory(subcat:SubCategory):Observable<any>
  {
    return this.http.post(this.url+'AddSubCategory',subcat,Requestheaders);
  }
  public DeleteCategory(id:string):Observable<any>
  {
    return this.http.delete<Category>(this.url+'DeleteCategory/'+id,Requestheaders);
  }
  public DeleteSubCategory(id:string):Observable<any>
  {
    return this.http.delete<SubCategory>(this.url+'DeleteSubCategory/'+id,Requestheaders);
  }
  public GetCategory():Observable<Category[]>
  {
    return this.http.get<Category[]>(this.url+'GetCategory/',Requestheaders);
  }
 
  public GetCatById(id:string):Observable<Category>
  {
    return this.http.get<Category>(this.url+'GetCatById/'+id,Requestheaders);
  }
  public GetSubcategory():Observable<SubCategory[]>
  {
    return this.http.get<SubCategory[]>(this.url+'GetSubcategory/',Requestheaders);
  }
  public UpdateCategory(category:Category):Observable<any>
  {
    return this.http.put<any>(this.url+'UpdateCategory',JSON.stringify(category),Requestheaders);
  }
 
}
