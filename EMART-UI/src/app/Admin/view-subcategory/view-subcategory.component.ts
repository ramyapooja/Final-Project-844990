import { Component, OnInit } from '@angular/core';
import { SubCategory } from 'src/app/Models/sub-category';
import {FormBuilder,FormGroup,Validators} from "@angular/forms";
import { AdminService } from 'src/app/Services/admin.service';
import { Router } from '@angular/router';
import { Category } from 'src/app/Models/category';

@Component({
  selector: 'app-view-subcategory',
  templateUrl: './view-subcategory.component.html',
  styleUrls: ['./view-subcategory.component.css']
})
export class ViewSubcategoryComponent implements OnInit {

  subcategory:SubCategory;
  categorylist:Category[];
  subcategorylist:SubCategory[];
  subcategoryForm:FormGroup;
  submitted:boolean=false;
  
  constructor(private formbuilder:FormBuilder,private service:AdminService,private route:Router) { 
    this.service.GetSubcategory().subscribe(res=>
      {
        this.subcategorylist=res;
        console.log(this.subcategorylist);
      },
      err=>
      {
        console.log(err);
      })
    
  }

  ngOnInit() {
    this.subcategoryForm=this.formbuilder.group({
      subcategoryId:[''],
      subcategoryName:[''],
      categoryId:[''],
      briefDetails:[''],
      gst:['']
    });
  }
  onSubmit()
  {
    this.submitted=true;
  }
  GetCategories()
   {
     this.service.GetCategory().subscribe(res=>
      {
        this.categorylist=res;
        console.log(this.categorylist);
      },
      err=>
      {
        console.log(err);
      })
    }

}
