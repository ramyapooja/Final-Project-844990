import { Component, OnInit } from '@angular/core';
import {FormBuilder,FormGroup,Validators} from "@angular/forms";
import { Items } from 'src/app/Models/items';
import { ItemService } from 'src/app/Services/item.service';
import { Category } from 'src/app/Models/category';
import { SubCategory } from 'src/app/Models/sub-category';
@Component({
  selector: 'app-add-items',
  templateUrl: './add-items.component.html',
  styleUrls: ['./add-items.component.css']
})
export class AddItemsComponent implements OnInit {
  sellerId:string;
  itemId:string;
  subcategoryId:string;
  itemName:string;
  categoryId:string;
  price:number;
  stockNumber:number;
  description:string;
  remarks:string;
  item:Items;
  img:string;
  selectedFile : File = null;
  list:Items[];
  categorylist:Category[];
  subcategorylist:SubCategory[];
  itemForm:FormGroup;
  submitted:boolean=false;
  constructor(private formbuilder:FormBuilder,private service:ItemService) { 
    this.service.GetCategory().subscribe(res=>
      {
        this.categorylist=res;
        console.log(this.categorylist);
      },
      err=>
      {
        console.log(err);
      })
    //this.GetSubCategories();
  }

  ngOnInit() {
    this.itemForm=this.formbuilder.group({
      sellerId:[''],
      
      categoryId:[''],
      subcategoryId:[''],
      price:['',[Validators.required,Validators.pattern('^[0-9]{9}$')]],
      itemName:['',[Validators.required,Validators.pattern('^[a-zA-Z]{3,15}$')]],
      description:[''],
      stockNumber:['',[Validators.required],Validators.pattern('^[0-9]{5}$')],
      remarks:[''],
      img:['']
    });
  }
  onSubmit()
  {
    this.submitted=true;
    if(this.itemForm.valid)
    {
    this.Add();
    }
  }
  get f()
{
  return this.itemForm.controls;
}
Add()
  {
    this.item=new Items();
    this.item.categoryId=(this.itemForm.value["categoryId"]);
    this.item.subcategoryId=(this.itemForm.value["subcategoryId"]);
    this.item.sellerId=localStorage.getItem('sellerId');
    this.item.itemId='I'+Math.floor(Math.random()*1000);
   
    this.item.price=this.itemForm.value["price"];
    this.item.itemName=this.itemForm.value["itemName"];
    this.item.description=this.itemForm.value["description"];
    this.item.stockNumber=this.itemForm.value["stockNumber"];
    this.item.remarks=this.itemForm.value["remarks"];
    this.item.img=this.img;
    console.log(this.item);
    this.service.AddItem(this.item).subscribe(res=>{
      console.log('Item Added')
    },err=>{
      console.log(err)
    

    })
  }
  //GetCategories()
    //{
    //  this.service.GetCategory().subscribe(res=>
      // {
       //  this.categorylist=res;
      //   console.log(this.categorylist);
     // },
     //  err=>
      // {
      //   console.log(err);
     //  })
  //   }
    GetSubCategories()
   {
    
        let id=this.itemForm.value["categoryId"];
        console.log(id);
        this.service.GetSubCategory(id).subscribe(res=>{
          this.subcategorylist=res;
          console.log(this.subcategorylist);

        })
       
     
    }
  Update()
  {
    this.item=new Items();
    this.item.sellerId=this.itemForm.value["sellerId"];
    
    this.item.categoryId=(this.itemForm.value["categoryName"]);
    this.item.subcategoryId=(this.itemForm.value["subcategoryName"]);
    this.item.price=this.itemForm.value["price"];
    this.item.itemName=this.itemForm.value["itemName"];
    this.item.description=this.itemForm.value["description"];
    this.item.stockNumber=this.itemForm.value["stockNumber"];
    this.item.remarks=this.itemForm.value["remarks"];
    console.log(this.item);
    this.service.UpdateItem(this.item).subscribe(res=>{
      console.log('Item Updated')
    })
  }
  fileEvent(event){
    this.img = event.target.files[0].name;
}
  
}
