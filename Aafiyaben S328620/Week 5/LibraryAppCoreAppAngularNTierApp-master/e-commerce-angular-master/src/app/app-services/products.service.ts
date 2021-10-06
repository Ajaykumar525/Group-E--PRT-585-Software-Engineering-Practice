import {Injectable } from '@angular/core';
export interface Product {
    id: string;					//	Ref	on	category	belongs	to
    categoryId: string;
    //	The	title
    title: string;
    //	Price
    price: number;
    //	Mark	product	with	specialproce
    isSpecial: boolean;
    //	Description
    desc: string;
    //	Path	to	small	image
    imageS: string;
    //	Path	to	large	image;
    imageL: string;
}
@Injectable()

export class ProductsService {


 products: Product[] = [
    {
        id: '1',
        categoryId: '1',
        title: 'Sherman ',
        price: 65,
        isSpecial: true,
        imageL: 'https://cdn.shopify.com/s/files/1/0047/5335/8922/products/john-jacobs-jj-e11549-c2-eyeglasses_john-jacobs-jj-e11549-c2-eyeglasses_g_2417_1024x1024.jpg?v=1621347947',
        imageS: 'https://cdn.shopify.com/s/files/1/0047/5335/8922/products/john-jacobs-jj-e11549-c2-eyeglasses_john-jacobs-jj-e11549-c2-eyeglasses_g_2417_1024x1024.jpg?v=1621347947',
        desc: 'Black Round Eyeglasses'
    },
    {
        id: '2',
        categoryId: '2',
        title: 'Esteem',
        price: 40,
        isSpecial: false,
        imageL: 'https://cdn.shopify.com/s/files/1/0047/5335/8922/products/vincent-chase-vc-s13980-c3-sunglasses_sunglasses_g_8735_1024x1024.jpg?v=1629878784',
        imageS: 'https://cdn.shopify.com/s/files/1/0047/5335/8922/products/vincent-chase-vc-s13980-c3-sunglasses_sunglasses_g_8735_1024x1024.jpg?v=1629878784',
        desc: 'Sunglass for Men'
    },
    {
        id: '3',
        categoryId: '3',
        title: 'Junior',
        price: 35,
        isSpecial: false,
        imageL: 'https://cdn.shopify.com/s/files/1/0047/5335/8922/products/lenskart-junior-lkj-e10001-c4-eyeglasses_Img1j_1024x1024.jpg?v=1623251063',
        imageS: 'https://cdn.shopify.com/s/files/1/0047/5335/8922/products/lenskart-junior-lkj-e10001-c4-eyeglasses_Img1j_1024x1024.jpg?v=1623251063',
        desc: 'Transparent Round Full Rim Kid Eyeglasses'
    },
    {
        id: '4',
        categoryId: '1',
        title: 'Coltrane',
        price: 95.99,
        isSpecial: false,
        imageL: 'https://cdn.shopify.com/s/files/1/0047/5335/8922/products/john-jacobs-jj-s12810-c5-sunglasses_g_7874_1024x1024.jpg?v=1629400598',
        imageS: 'https://cdn.shopify.com/s/files/1/0047/5335/8922/products/john-jacobs-jj-s12810-c5-sunglasses_g_7874_1024x1024.jpg?v=1629400598',
        desc: 'Rose Gold Round Glasses'
    },
    {
        id: '5',
        categoryId: '3',
        title: 'Blue Wayfarer sunglasses',
        price: 45,
        isSpecial: false,
        imageL: 'https://cdn.shopify.com/s/files/1/0047/5335/8922/products/john-jacobs-jj-s12955-c3-sunglasses_sunglasses_g_1525_40709c74-e38b-45c2-b614-58a975439d4f_1024x1024.jpg?v=1631940200',
        imageS: 'https://cdn.shopify.com/s/files/1/0047/5335/8922/products/john-jacobs-jj-s12955-c3-sunglasses_sunglasses_g_1525_40709c74-e38b-45c2-b614-58a975439d4f_1024x1024.jpg?v=1631940200',
        desc: 'Blue Transparent wayfarer sunglasses.'
    },
    {
        id: '6',
        categoryId: '4',
        title: 'Everton',
        price: 100,
        isSpecial: false,
        imageL: 'https://cdn.shopify.com/s/files/1/0047/5335/8922/products/john-jacobs-jj-s13150-c1-sunglasses_eyeglasses_g_2468_1024x1024.jpg?v=1629455319',
        imageS: 'https://cdn.shopify.com/s/files/1/0047/5335/8922/products/john-jacobs-jj-s13150-c1-sunglasses_eyeglasses_g_2468_1024x1024.jpg?v=1629455319',
        desc: 'Tortoise Golden Cat Eye Sunglasses'
    },
    {
        id: '7',
        categoryId: '4',
        title: 'Vincent Chase',
        price: 68,
        isSpecial: false,
        imageL: 'https://cdn.shopify.com/s/files/1/0047/5335/8922/products/vincent-chose-vc-s13841-frll-rum-c2-sunglasses_sunglasses_j_0231_1_1024x1024.jpg?v=1632552980',
        imageS: 'https://cdn.shopify.com/s/files/1/0047/5335/8922/products/vincent-chose-vc-s13841-frll-rum-c2-sunglasses_sunglasses_j_0231_1_1024x1024.jpg?v=1632552980',
        desc: 'Silver Rectangle Full Rim Unisex Sunglasses	'
    },
    {
        id: '8',
        categoryId: '4',
        title: 'Vincent Chase',
        price: 69,
        isSpecial: false,
        imageL: 'https://cdn.shopify.com/s/files/1/0047/5335/8922/products/vincent-chase-vc-s13110-c5-sunglasses_img_2131_1024x1024.jpg?v=1631333028',
        imageS: 'https://cdn.shopify.com/s/files/1/0047/5335/8922/products/vincent-chase-vc-s13110-c5-sunglasses_img_2131_1024x1024.jpg?v=1631333028',
        desc: 'Gold Aviator Full Rim Unisex Sunglasses '
    },
    {
        id: '9',
        categoryId: '5',
        title: 'Vincent Chase',
        price: 69,
        isSpecial: false,
        imageL: 'https://cdn.shopify.com/s/files/1/0047/5335/8922/products/vincent-chase-polarized-vc-s11164-c5-sunglasses_sunglasses_g_1634_1_1_1024x1024.jpg?v=1629877977',
        imageS: 'https://cdn.shopify.com/s/files/1/0047/5335/8922/products/vincent-chase-polarized-vc-s11164-c5-sunglasses_sunglasses_g_1634_1_1_1024x1024.jpg?v=1629877977',
        desc: 'Brown Round Full Rim Unisex Sunglasses '
    }, {
        id: '10',
        categoryId: '5',
        title: 'Vincent Chase',
        price: 47,
        isSpecial: false,
        imageL: 'https://cdn.shopify.com/s/files/1/0047/5335/8922/products/vincent-chase-vc-s13832-c2-suglasses_g_5259_1024x1024.jpg?v=1629446725',
        imageS: 'https://cdn.shopify.com/s/files/1/0047/5335/8922/products/vincent-chase-vc-s13832-c2-suglasses_g_5259_1024x1024.jpg?v=1629446725',
        desc: 'Silver Round Full Rim Unisex Sunglasses.'
    }];

    getProducts() {
        return this.products;
    }

    getProduct(id: string): Product {

       return this.products.filter((product:Product)=> { return product.id == id})[0]
    }

}
