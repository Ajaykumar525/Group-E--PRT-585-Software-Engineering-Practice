/**
 * Created by Hossam Elnabawy on 31/03/2017.
 */
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

let products: Product[] = [
   {
    id: '1',
    categoryId: '1',
    title: 'Round Shape',
    price: 0.5,
    isSpecial: true,
    imageL: 'https://sc04.alicdn.com/kf/H1d08af9cabb64b598e83e33bc1672f813.jpg',
    imageS: 'https://sc04.alicdn.com/kf/H1d08af9cabb64b598e83e33bc1672f813.jpg',
    desc: ''
  },
  {
    id: '2',
    categoryId: '2',
    title: 'Square',
    price: 1.2,
    isSpecial: false,
    imageL: 'http://placehold.it/1110x480',
    imageS: 'http://placehold.it/270x171',
    desc: ''
  },
  {
    id: '3',
    categoryId: '3',
    title: 'Sunglass',
    price: 1.7,
    isSpecial: false,
    imageL: 'http://placehold.it/1110x480',
    imageS: 'http://placehold.it/270x171',
    desc: ''
  },
    {
        id: '4',
        categoryId: '1',
        title: 'Blue Light Glasses',
        price: 1.5,
        isSpecial: false,
        imageL: 'http://placehold.it/1110x480',
        imageS: 'http://placehold.it/270x171',
        desc: ''
    },
  {
    id: '5',
    categoryId: '3',
    title: 'Everyday look',
    price: 2.35,
    isSpecial: false,
    imageL: 'http://placehold.it/1110x480',
    imageS: 'http://placehold.it/270x171',
    desc: ''
  },
  {
    id: '6',
    categoryId: '4',
    title: 'Classic for men',
    price: 5.60,
    isSpecial: false,
    imageL: 'http://placehold.it/1110x480',
    imageS: 'http://placehold.it/270x171',
    desc: '	'
  },
  {
    id: '7',
    categoryId: '4',
    title: 'Cat Shape',
    price: 4.85,
    isSpecial: false,
    imageL: 'http://placehold.it/1110x480',
    imageS: 'http://placehold.it/270x171',
    desc: '	'
  },
  {
    id: '8',
    categoryId: '4',
    title: 'Harry potter style',
    price: 9.20,
    isSpecial: false,
    imageL: 'http://placehold.it/1110x480',
    imageS: 'http://placehold.it/270x171',
    desc: ''
  },
  {
    id: '9',
    categoryId: '5',
    title: 'Tuna',
    price: 3.45,
    isSpecial: false,
    imageL: 'http://placehold.it/1110x480',
    imageS: 'http://placehold.it/270x171',
    desc: ''
  }, {
    id: '10',
    categoryId: '5',
    title: 'Salmon',
    price: 4.55,
    isSpecial: false,
    imageL: 'http://placehold.it/1110x480',
    imageS: 'http://placehold.it/270x171',
    desc: ''
  },
  {
    id: '11',
    categoryId: '5',
    title: 'Oysters',
    price: 7.80,
    isSpecial: false,
    imageL: 'http://placehold.it/1110x480',
    imageS: 'http://placehold.it/270x171',
    desc: ''
  }, {
    id: '12',
    categoryId: '5',
    title: 'Scalops',
    price: 2.70,
    isSpecial: false,
    imageL: 'http://placehold.it/1110x480',
    imageS: 'http://placehold.it/270x171',
    desc: ''
  },
  {
    id: '13',
    categoryId: '6',
    title: 'Banana',
    price: 1.55,
    isSpecial: false,
    imageL: 'http://placehold.it/1110x480',
    imageS: 'http://placehold.it/270x171',
    desc: ''
  },
  {
    id: '14',
    categoryId: '6',
    title: 'Cucumber',
    price: 1.05,
    isSpecial: false,
    imageL: 'http://placehold.it/1110x480',
    imageS: 'http://placehold.it/270x171',
    desc: ''
  },
  {
    id: '15',
    categoryId: '6',
    title: 'Apple',
    price: 0.80,
    isSpecial: false,
    imageL: 'http://placehold.it/1110x480',
    imageS: 'http://placehold.it/270x171',
    desc: ''
  },
  {
    id: '16',
    categoryId: '6',
    title: 'Lemon',
    price: 3.20,
    isSpecial: false,
    imageL: 'http://placehold.it/1110x480',
    imageS: 'http://placehold.it/270x171',
    desc: ''
  },
  {
    id: '17',
    categoryId: '6',
    title: 'Pear',
    price: 4.25,
    isSpecial: false,
    imageL: 'http://placehold.it/1110x480',
    imageS: 'http://placehold.it/270x171',
    desc: ''
  }];

export function getProducts() {
  return products;
}

export function getProduct(id: string): Product {

  return products.filter((product:Product)=> { return product.id == id})[0]
}

