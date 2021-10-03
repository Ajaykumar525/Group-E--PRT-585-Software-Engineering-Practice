export interface Icategories {
  id: number;
  title: string;
  desc: string;
  image: string;

  link: string
}
export interface IproductCategories {
    categoryId: string;
    title: string;

}
export class Category {

  constructor(public id: number, public title: string, public desc: string, public image: string,public link: string) {
  }


}
export let ProductsCategories: IproductCategories[] = [
    {categoryId: '0', title:'All'},
    {categoryId: '1', title:'For Woman'},
    {categoryId: '2', title:'For Men'},
    {categoryId: '3', title:'For Kids'}
];
export let Categories:Category[] = [
  new Category(1, "For Woman", "find the new look for your everyday fashion", "https://www.mauijim.com/medias/Homepage-SubHero-Even-Keel-700x330.jpg?context=bWFzdGVyfHJvb3R8MjE1NTU4fGltYWdlL2pwZWd8aDI5L2hmOC85MzM3NTUxNjgzNjE0L0hvbWVwYWdlIFN1Ykhlcm8gRXZlbiBLZWVsIDcwMHgzMzAuanBnfGY3YzgwYzEwZDgwYTA3YjY1MmVkOGNkOWVhZmMyMTQ4YmJmNzIwNGUxNmEwYTg5OGE5ZDkyNzg1ZWU1NTUxMDQ","#"),
  new Category(2, "For Men", "Always Classic", "https://i.pinimg.com/originals/d8/0a/76/d80a76de1f070cbb7465018dfc550d38.jpg", "#"),
  new Category(3, "For Kids", "choose new style for your kids", "https://www.theschoolrun.com/sites/theschoolrun.com/files/u9/blinx.png", "#"),
];
