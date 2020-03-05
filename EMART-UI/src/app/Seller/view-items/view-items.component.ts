import { Component, OnInit } from '@angular/core';
import {FormBuilder,FormGroup,Validators} from "@angular/forms";
import { Items } from 'src/app/Models/items';
import { ItemService } from 'src/app/Services/item.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-view-items',
  templateUrl: './view-items.component.html',
  styleUrls: ['./view-items.component.css']
})
export class ViewItemsComponent implements OnInit {

  
  item:Items;
  itemlist:Items[];
  itemForm:FormGroup;
  submitted:boolean=false;
  img:string;
  constructor(private formbuilder:FormBuilder,private service:ItemService,private route:Router) {
    this.service.ViewItems().subscribe(res=>
      {
        this.itemlist=res;
        console.log(this.itemlist);
      },
      err=>
      {
        console.log(err);
      })
    
   }

  ngOnInit() {
    this.itemForm=this.formbuilder.group({
      sellerId:[''],
      itemId:[''],
      categoryId:[''],
      subcategoryId:[''],
      price:[''],
      itemName:[''],
      description:[''],
      stockNumber:[''],
      remarks:[''],
      img:['']
    });
    
  }
  onSubmit()
  {
    this.submitted=true;
  }
  Delete(id:string)
  {
  
    this.service.DeleteItem(id).subscribe(res=>{
      console.log('Item deleted');
    },err=>{
      console.log(err);
    }
      )
  }
  EditItem(itemId:string)
  {
    this.service.GetItem(itemId).subscribe(res=>{
      this.item=res;
      console.log(this.item);
      this.itemForm.setValue({
        
        itemId:this.item.itemId,
        itemName:this.item.itemName,
        price:this.item.price,
        stockNumber:this.item.stockNumber,
        description:this.item.description,
        remarks:this.item.remarks,
        categoryId:this.item.categoryId,
        subcategoryId:this.item.subcategoryId,
        sellerId:this.item.sellerId,
        img:this.item.img
    })
  })

  }
  Update()
  {
    this.item=new Items();
    this.item.sellerId=this.itemForm.value["sellerId"];
    this.item.itemId=this.itemForm.value["itemId"];
    this.item.categoryId=(this.itemForm.value["categoryName"]);
    this.item.subcategoryId=(this.itemForm.value["subcategoryName"]);
    this.item.price=this.itemForm.value["price"];
    this.item.itemName=this.itemForm.value["itemName"];
    this.item.description=this.itemForm.value["description"];
    this.item.stockNumber=this.itemForm.value["stockNumber"];
    this.item.remarks=this.itemForm.value["remarks"];
    this.item.img=this.img;
    console.log(this.item);
    this.service.UpdateItem(this.item).subscribe(res=>{
      console.log('Item Updated')
    })
  }
  fileEvent(event){
    this.img = event.target.files[0].name;
}


}
