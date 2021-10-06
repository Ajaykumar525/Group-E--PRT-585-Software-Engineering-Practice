interface ISlider {
  title: string;
  desc: string;
  image: string;
}

export class SliderClass {
  constructor(public title: string, public desc: string, public image: string) {
  }
}

export let Sliders:SliderClass[] = [
  new SliderClass("Different types of product", "", "https://mauijimcorporategifts.com/wp-content/uploads/2018/01/how-does-gifting-work.jpg"),
  new SliderClass("Different shades & Different colour", "", "https://media-cldnry.s-nbcnews.com/image/upload/t_fit-1500w,f_auto,q_auto:best/newscms/2020_35/3406958/sunglasses-men-women-kr-2x1-tease-200824.jpg"),
  new SliderClass("In different Brands", "", "https://livealoha.mauijim.com/wp-content/uploads/2020/08/2020-Sunglass-Trends.jpg"),
    
];
