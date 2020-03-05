import { Component, OnInit } from '@angular/core';
import {FormBuilder,FormGroup,Validators} from "@angular/forms";
import { AdminService } from 'src/app/Services/admin.service';
import { Router } from '@angular/router';
import { Category } from 'src/app/Models/category';
@Component({
  selector: 'app-view-category',
  templateUrl: './view-category.component.html',
  styleUrls: ['./view-category.component.css']
})
export class ViewCategoryComponent implements OnInit {

  category:Category;
  categorylist:Category[];
  categoryForm:FormGroup;
  submitted:boolean=false;

  constructor(private formbuilder:FormBuilder,private service:AdminService,private route:Router) { 
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

  ngOnInit() {
    this.categoryForm=this.formbuilder.group({
      categoryId:[''],
      categoryName:[''],
      briefDetails:['']
    });
  }
  EditCategory(categoryId:string)
  {
    this.service.GetCatById(categoryId).subscribe(res=>{
      this.category=res;
      console.log(this.category);
      this.categoryForm.setValue({
        
        categoryId:this.category.categoryId,
        categoryName:this.category.categoryName,
        briefDetails:this.category.briefDetails
    })
  })

  }
  Update()
  {
    this.category=new Category();
    this.category.categoryId=this.categoryForm.value["categoryId"];
    this.category.categoryName=this.categoryForm.value["categoryName"];
    this.category.briefDetails=this.categoryForm.value["briefDetails"];
    
    console.log(this.category);
    this.service.UpdateCategory(this.category).subscribe(res=>{
      console.log('Category Updated')
    })
  }

}
