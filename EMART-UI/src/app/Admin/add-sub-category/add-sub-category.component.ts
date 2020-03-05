import { Component, OnInit } from '@angular/core';
import {FormBuilder,FormGroup,Validators} from "@angular/forms";
import { SubCategory } from 'src/app/Models/sub-category';
import { AdminService } from 'src/app/Services/admin.service';
import { Category } from 'src/app/Models/category';
@Component({
  selector: 'app-add-sub-category',
  templateUrl: './add-sub-category.component.html',
  styleUrls: ['./add-sub-category.component.css']
})
export class AddSubCategoryComponent implements OnInit {
  subcategoryId:string;
  subcategoryName:string;
  categoryId:string;
  briefDetails:string;
  gst:string;
  subcatForm:FormGroup;
  submitted:boolean=false;
  subcat:SubCategory;
  categorylist:Category[];
  subcategorylist:SubCategory[];
    constructor(private formbuilder:FormBuilder,private service:AdminService) {
      this.GetCategories();
     }
  
    ngOnInit() {
      this.subcatForm=this.formbuilder.group({
        
        subcategoryName:['',Validators.required],
        categoryName:[''],
        briefDetails:[''],
        gst:['',Validators.required]
      });
    }
    onSubmit()
    {
      this.submitted=true;
      this.Add();
    }
    get f()
{
  return this.subcatForm.controls;
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
Add()
  {
    this.subcat=new SubCategory();
    this.subcat.subcategoryId='SC'+Math.floor(Math.random()*100);
    this.subcat.subcategoryName=this.subcatForm.value["subcategoryName"];
    this.subcat.categoryId=(this.subcatForm.value["categoryName"]);
    this.subcat.briefDetails=this.subcatForm.value["briefDetails"];
    this.subcat.gst=this.subcatForm.value["gst"];
    
    console.log(this.subcat);
    this.service.AddSubcategory(this.subcat).subscribe(res=>{
      console.log('Subcategory Added')
    },err=>{
      console.log(err)
    

    })
  }
  Delete()
  {
    
    let id=this.subcatForm.value["subcategoryId"];
    console.log(id);
    this.service.DeleteSubCategory(id).subscribe(res=>{
      console.log('SubCategory deleted');
    },err=>{
      console.log(err);
    }
      )
  }
}
