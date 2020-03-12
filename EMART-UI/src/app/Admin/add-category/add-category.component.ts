import { Component, OnInit } from '@angular/core';
import {FormBuilder,FormGroup,Validators} from "@angular/forms";
import { Category } from 'src/app/Models/category';
import { AdminService } from 'src/app/Services/admin.service';
@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent implements OnInit {
categoryId:string;
categoryName:string;
briefDetails:string;
catForm:FormGroup;
submitted:boolean=false;
cat:Category;
list:Category[];
  constructor(private formbuilder:FormBuilder,private service:AdminService) { }

  ngOnInit() {
    this.catForm=this.formbuilder.group({
      categoryId:['',Validators.required],
      categoryName:['',Validators.required,Validators.pattern('^[a-zA-Z]{3,6}$')],
      briefDetails:['']
    });
  }
  onSubmit()
  {
    this.submitted=true;
    this.Add();

  }
  get f()
{
  return this.catForm.controls;
}
Add()
  {
    this.cat=new Category();
    this.cat.categoryId='C'+Math.floor(Math.random()*1000);
    this.cat.categoryName=this.catForm.value["categoryName"];
    this.cat.briefDetails=this.catForm.value["briefDetails"];
    
    console.log(this.cat);
    this.service.AddCategory(this.cat).subscribe(res=>{
      console.log('category Added')
    },err=>{
      console.log(err)
    

    })
  }
  Delete()
  {
    let id=this.catForm.value["categoryId"];
    this.service.DeleteCategory(id).subscribe(res=>{
      console.log('Category deleted');
    },err=>{
      console.log(err);
    }
      )
  }

}
