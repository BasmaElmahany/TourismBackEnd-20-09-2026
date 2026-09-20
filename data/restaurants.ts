import { Restaurant } from "../models/tourism.models";

// Raw restaurant data (kept compatible with previous shape)
export const RAW_RESTAURANTS: any[] = [
  {
    id: "minya_1",
    name: {
      en: "Orked Restaurant",
      ar: "مطعم أوركيد"
    },
    description: {
      en: "Traditional Egyptian cuisine by the Nile with scenic views",
      ar: "مأكولات مصرية تقليدية مطلة على النيل"
    },
  imageUrl: "assets/images/unnamed (3).png",
  imageGallery: ["assets/images/490768648_1076963261132257_5356947501708733683_n.jpg"
   
  ],
  // Menu URL as fallback
  menuUrl: '/assets/menus/minya_1.pdf',
    latitude: 28.1099,
    longitude: 30.7503,
    rating: 4.3,
    reviewCount: 2635,
    cuisineType: {
      en: "Egyptian",
      ar: "مصري"
    },
    priceRange: {
      en: "Mid-range",
      ar: "متوسط"
    },
   openingHours: {
  en: "Wed 12:00 PM – 2:00 AM\nThu 12:00 PM – 2:00 AM\nFri 12:00 PM – 2:00 AM\nSat 12:00 PM – 2:00 AM\nSun 12:00 PM – 2:00 AM\nMon 12:00 PM – 2:00 AM\nTue 12:00 PM – 2:00 AM",
  ar: "الأربعاء ١٢:٠٠م–٢:٠٠ص\nالخميس ١٢:٠٠م–٢:٠٠ص\nالجمعة ١٢:٠٠م–٢:٠٠ص\nالسبت ١٢:٠٠م–٢:٠٠ص\nالأحد ١٢:٠٠م–٢:٠٠ص\nالاثنين ١٢:٠٠م–٢:٠٠ص\nالثلاثاء ١٢:٠٠م–٢:٠٠ص"
},

    specialties: [],
    contactInfo: {
      phone: {
        en: "086 2356999",
        ar: "٠٨٦ ٢٣٥٦٩٩٩"
      },
      email: ""
    },
    features: [
      {
        en: "Nile View",
        ar: "إطلالة على النيل"
      }
    ]
  },
  {
    id: "minya_2",
    name: {
      en: "Bayada Seafood",
      ar: "مطعم البياضة"
    },
    description: {
      en: "Seafood and classic Egyptian dishes",
      ar: "أطباق سمك وأكلات مصرية كلاسيكية"
    },
    imageUrl: "assets/images/Minya-seafood-.jpg",
    imageGallery: ["assets/images/menus/bayada_menu.jpg"],
    latitude: 28.099254419637028,
    longitude: 30.756527154526424,
    rating: 3.9,
    reviewCount: 142,
    cuisineType: {
      en: "Seafood, Egyptian",
      ar: "أسماك، مصري"
    },
    priceRange: {
      en: "Mid-range",
      ar: "متوسط"
    },
    openingHours: {
  en: "Wed 8:00 AM – 2:00 AM\nThu 8:00 AM – 2:00 AM\nFri 8:00 AM – 2:00 AM\nSat 8:00 AM – 2:00 AM\nSun 8:00 AM – 12:00 AM\nMon 8:00 AM – 2:00 AM\nTue 8:00 AM – 2:00 AM",
  ar: "الأربعاء ٨:٠٠ص–٢:٠٠ص\nالخميس ٨:٠٠ص–٢:٠٠ص\nالجمعة ٨:٠٠ص–٢:٠٠ص\nالسبت ٨:٠٠ص–٢:٠٠ص\nالأحد ٨:٠٠ص–١٢:٠٠ص\nالاثنين ٨:٠٠ص–٢:٠٠ص\nالثلاثاء ٨:٠٠ص–٢:٠٠ص"
},

    specialties: [],
    contactInfo: {
      phone: {
        en: "086 2369550",
        ar: "٠٨٦ ٢٣٦٩٥٥٠"
      },
      email: ""
    },
     features: [
  { en: "Restroom", ar: "مرحاض" }
]
  },

  // ======= باقي إدخالات المنيا =======
//   {
//     id: "minya_3",
//     name: {
//       en: "Fresh Food Grill Restaurant",
//       ar: "مطعم فريش فود جريل"
//     },
//     description: {
//       en: "Mediterranean and Egyptian grilled dishes",
//       ar: "أطباق مشوية متوسطية ومصرية"
//     },
//     imageUrl: "assets/images/Fresh Food Grill Restaurant_n.jpg",
//     latitude: 28.07367330527575, 
//     longitude: 30.816348988009075,
//     rating: 4.7,
//     reviewCount: 448,
//     cuisineType: {
//       en: "Mediterranean, Egyptian",
//       ar: "متوسطي، مصري"
//     },
//     priceRange: {
//       en: "Mid-range",
//       ar: "متوسط"
//     },
//    openingHours: {
//   en: "Wed 11:30 AM – 3:00 AM\nThu 11:30 AM – 3:00 AM\nFri 1:00 PM – 3:00 AM\nSat 11:30 AM – 3:00 AM\nSun 11:30 AM – 3:00 AM\nMon 11:30 AM – 3:00 AM",
//   ar: "الأربعاء ١١:٣٠ص–٣:٠٠ص\nالخميس ١١:٣٠ص–٣:٠٠ص\nالجمعة ١:٠٠م–٣:٠٠ص\nالسبت ١١:٣٠ص–٣:٠٠ص\nالأحد ١١:٣٠ص–٣:٠٠ص\nالاثنين ١١:٣٠ص–٣:٠٠ص"
// },

//     specialties: [],
//     contactInfo: {
//       phone: {
//         en: "+20 102 000 4495",
//         ar: "+٢٠ ١٠٢ ٠٠٠ ٤٤٩٥"
//       },
//       email: ""
//     },
//     features: [
//   { en: "Restroom", ar: "مرحاض" }
// ]

//   },
  // {
  //   id: "minya_4",
  //   name: {
  //     en: "Toscanini",
  //     ar: "توسكاني"
  //   },
  //   description: {
  //     en: "Italian / mixed cuisine with Nile view",
  //     ar: "مطبخ إيطالي / مختلط مع إطلالة على النيل"
  //   },
  //   imageUrl: "assets/images/توسكاني.jpg",
  //   latitude: 0,
  //   longitude: 0,
  //   rating: 4.5,
  //   reviewCount: 2,
  //   cuisineType: {
  //     en: "Italian, Mixed",
  //     ar: "إيطالي، مختلط"
  //   },
  //   priceRange: {
  //     en: "Mid-range",
  //     ar: "متوسط"
  //   },
  //   openingHours: {
  //     en: "",
  //     ar: ""
  //   },
  //   specialties: [],
  //   contactInfo: {
  //     phone: {
  //       en: "+20 127 272 7220",
  //       ar: "+٢٠ ١٢٧ ٢٧٢ ٧٢٢٠"
  //     },
  //     email: ""
  //   },
  //   features: []
  // },
//   {
//     id: "minya_5",
//     name: {
//       en: "Bondokah Restaurant",
//       ar: "مطعم بوندقة"
//     },
//     description: {
//       en: "Casual dining with Egyptian classics like koshari",
//       ar: "مطعم عادي يقدم أكلات مصرية مثل الكشري"
//     },
//     imageUrl: "assets/images/Bondokah Restaurant.jpg",
//     latitude: 28.102050188865025, 
//     longitude: 30.754808388008396,
//     rating: 3.8,
//     reviewCount: 2458,
//     cuisineType: {
//       en: "Egyptian",
//       ar: "مصري"
//     },
//     priceRange: {
//       en: "Affordable",
//       ar: "مناسب"
//     },
//    openingHours: {
//   en: "Wednesday 9:00 AM–3:00 AM, Thursday 9:00 AM–3:00 AM, Friday 12:00 PM–3:00 AM, Saturday 12:00 PM–3:00 AM, Sunday 9:00 AM–3:00 AM, Monday 9:00 AM–3:00 AM, Tuesday 9:00 AM–3:00 AM",
//   ar: "الأربعاء ٩:٠٠ص–٣:٠٠ص، الخميس ٩:٠٠ص–٣:٠٠ص، الجمعة ١٢:٠٠م–٣:٠٠ص، السبت ١٢:٠٠م–٣:٠٠ص، الأحد ٩:٠٠ص–٣:٠٠ص، الاثنين ٩:٠٠ص–٣:٠٠ص، الثلاثاء ٩:٠٠ص–٣:٠٠ص"
// },

//     specialties: [],
//     contactInfo: {
//       phone: {
//         en: "086 2334141",
//         ar: "٠٨٦ ٢٣٣٤١٤١"
//       },
//       email: ""
//     },
//        features: [
//   { en: "Restroom", ar: "مرحاض" }
// ]
//   },

  // ======= ملوي (Mallawi) =======
  {
    id: "mallawi_1",
    name: {
      en: "Chicky Door",
      ar: "تشيكي دور"
    },
    description: {
      en: "Fast food / take-away in Mallawi",
      ar: "وجبات سريعة / تيك أواي في ملوي"
    },
    imageUrl: "assets/images/Chicky Door.jpg",
    latitude: 27.7381296420425,
    longitude:  30.847042457333302,
    rating:3.9,
    reviewCount: 81,
    cuisineType: {
      en: "Fast Food",
      ar: "وجبات سريعة"
    },
    priceRange: {
      en: "Low to Mid",
      ar: "منخفض إلى متوسط"
    },
    openingHours: {
      en: "",
      ar: ""
    },
    specialties: [],
    contactInfo: {
      phone: {
        en: "01050315333 / 01555291223",
        ar: "01050315333 / 01555291223"
      },
      email: ""
    },
    features: []
  },
  {
    id: "mallawi_2",
    name: {
      en: "Beit ElEzz (Beit El Ezz Mallawi)",
      ar: "مطعم بيت العز"
    },
    description: {
      en: "Family style restaurant specializing in grills, mandi, pizza",
      ar: "مطعم عائلي متخصص في المشاوي، المندي، البيتزا والطواجن"
    },
    imageUrl: "assets/images/Beit ElEzz (Beit El Ezz Mallawi).jpg",
    latitude: 27.738564389916235,
    longitude: 30.84441498616867,
    rating: 4.3,
    reviewCount: 276,
    cuisineType: {
      en: "Grill, Mandi, Pizza",
      ar: "مشاوي، مندي، بيتزا"
    },
    priceRange: {
      en: "Mid-range",
      ar: "متوسط"
    },
   openingHours: {
  en: "Wed Open 24 hours\nThu 10:00 AM – 2:00 AM\nFri 10:00 AM – 12:00 AM\nSat Open 24 hours\nSun Open 24 hours\nMon Open 24 hours",
  ar: "الأربعاء نعمل على مدار 24 ساعة\nالخميس ١٠:٠٠ص–٢:٠٠ص\nالجمعة ١٠:٠٠ص–١٢:٠٠ص\nالسبت نعمل على مدار 24 ساعة\nالأحد نعمل على مدار 24 ساعة\nالاثنين نعمل على مدار 24 ساعة"
}
,
    specialties: [],
    contactInfo: {
      phone: {
        en: "01110341113 / 01050205761",
        ar: "01110341113 / 01050205761"
      },
      email: ""
    },
    features: []
  },
  // {
  //   id: "mallawi_3",
  //   name: {
  //     en: "Duwwar El Omda (Dowar El Omda)",
  //     ar: "مطعم دوار العمده"
  //   },
  //   description: {
  //     en: "Local restaurant in Mallawi",
  //     ar: "مطعم محلي في ملوي"
  //   },
  //   imageUrl: "assets/images/مطعم دوار العمده.jpg",
  //   latitude: 0,
  //   longitude: 0,
  //   rating: 0,
  //   reviewCount: 0,
  //   cuisineType: {
  //     en: "Egyptian / Grill",
  //     ar: "مصري / مشاوي"
  //   },
  //   priceRange: {
  //     en: "Low to Mid",
  //     ar: "منخفض إلى متوسط"
  //   },
  //   openingHours: {
  //     en: "10:00 AM - 10:00 PM",
  //     ar: "10:00 صباحاً - 10:00 مساءً"
  //   },
  //   specialties: [],
  //   contactInfo: {
  //     phone: {
  //       en: "01000907292",
  //       ar: "01000907292"
  //     },
  //     email: ""
  //   },
  //   features: []
  // },
  {
    id: "mallawi_4",
    name: {
      en: "Ayman Restaurant (مطعم أيمن)",
      ar: "مطعم أيمن"
    },
    description: {
      en: "Local eatery in Mallawi (delivery available)",
      ar: "مطعم محلي في ملوي (توصيل متاح)"
    },
    imageUrl: "assets/images/Ayman Restaurant (مطعم أيمن).jpg",
    latitude: 27.738153654342618,
    longitude: 30.844708940717766,
    rating: 4.2,
    reviewCount: 27,
    cuisineType: {
      en: "Egyptian",
      ar: "مصري"
    },
    priceRange: {
      en: "Low to Mid",
      ar: "منخفض إلى متوسط"
    },
   openingHours: {
  en: "Wed 3:00 PM – 3:00 AM\nThu 3:00 PM – 3:00 AM\nFri 3:00 PM – 3:00 AM\nSat 3:00 PM – 3:00 AM\nSun 3:00 PM – 3:00 AM\nMon Closed",
  ar: "الأربعاء ٣:٠٠م–٣:٠٠ص\nالخميس ٣:٠٠م–٣:٠٠ص\nالجمعة ٣:٠٠م–٣:٠٠ص\nالسبت ٣:٠٠م–٣:٠٠ص\nالأحد ٣:٠٠م–٣:٠٠ص\nالاثنين مغلق"
}
,
    specialties: [],
    contactInfo: {
      phone: {
        en: "01090751710 / 01140008535",
        ar: "01090751710 / 01140008535"
      },
      email: ""
    },
    features: []
  },

  // ======= بني مزار (Beni Mazar) =======
  {
    id: "beni_1",
    name: {
      en: "Piano Cafe",
      ar: "بيانو كافيه"
    },
    description: {
      en: "Cafe & light meals — popular in Beni Mazar",
      ar: "كافيه ووجبات خفيفة — مشهور في بني مزار"
    },
    imageUrl: "assets/images/Piano Cafe.jpg",
    latitude: 28.495016204254583, 
    longitude: 30.807570087998325,
    rating: 3.8,
    reviewCount: 137,
    cuisineType: {
      en: "Cafe",
      ar: "كافيه"
    },
    priceRange: {
      en: "Low to Mid",
      ar: "منخفض إلى متوسط"
    },
   openingHours: {
  en: "Wed 8:30 AM – 2:00 AM\nThu 8:30 AM – 2:00 AM\nFri 8:30 AM – 2:00 AM\nSat 8:30 AM – 2:00 AM\nSun 8:30 AM – 2:00 AM\nMon 8:30 AM – 2:00 AM",
  ar: "الأربعاء ٨:٣٠ص–٢:٠٠ص\nالخميس ٨:٣٠ص–٢:٠٠ص\nالجمعة ٨:٣٠ص–٢:٠٠ص\nالسبت ٨:٣٠ص–٢:٠٠ص\nالأحد ٨:٣٠ص–٢:٠٠ص\nالاثنين ٨:٣٠ص–٢:٠٠ص"
},

    specialties: [
      { en: "Coffee", ar: "قهوة" },
      { en: "Sandwiches", ar: "ساندوتشات" }
    ],
    contactInfo: {
      phone: { en: "", ar: "" },
      email: ""
    },
    features: [
      { en: "Outdoor Seating", ar: "جلسات خارجية" }
    ]
  },
  {
    id: "beni_2",
    name: {
      en: "El Omda (Al Omda)",
      ar: "مطعم العمدة"
    },
    description: {
      en: "Local grill & family restaurant in Beni Mazar",
      ar: "مطعم مشاوي وعائلي في بني مزار"
    },
    imageUrl: "assets/images/El Omda (Al Omda).png",
    latitude: 28.49868749709676, 
    longitude:30.80452639764266,
    rating: 3.7
,
    reviewCount: 101,
    cuisineType: {
      en: "Egyptian / Grill",
      ar: "مصري / مشاوي"
    },
    priceRange: {
      en: "Low to Mid",
      ar: "منخفض إلى متوسط"
    },
    openingHours: {
      en: "10:00 AM - 11:00 PM",
      ar: "10:00 صباحاً - 11:00 مساءً"
    },
    specialties: [
      { en: "Grills", ar: "مشاوي" },
      { en: "Masry Dishes", ar: "أكلات مصرية" }
    ],
    contactInfo: {
      phone: { en: "01092937948", ar: "٠١٠٩٢٩٣٧٩٤٨" },
      email: ""
    },
    features: []
  },
  {
    id: "beni_3",
    name: {
      en: "Tito's Restaurant - Beni Mazar",
      ar: "مطعم تيتو"
    },
    description: {
      en: "Casual local restaurant listed on TripAdvisor",
      ar: "مطعم محلي مدرج في TripAdvisor"
    },
    imageUrl: "assets/images/Tito's Restaurant - Beni Mazar.jpg",
    latitude: 28.495962531207283,
    longitude: 30.813360059162747,
    rating: 3.1
,
    reviewCount: 35,
    cuisineType: {
      en: "Egyptian",
      ar: "مصري"
    },
    priceRange: {
      en: "Low to Mid",
      ar: "منخفض إلى متوسط"
    },
   openingHours: {
  en: "Wed 10:00 AM – 12:00 AM\nThu 10:00 AM – 12:00 AM\nFri Closed\nSat 10:00 AM – 12:00 AM\nSun 10:00 AM – 12:00 AM\nMon 10:00 AM – 12:00 AM",
  ar: "الأربعاء ١٠:٠٠ص–١٢:٠٠ص\nالخميس ١٠:٠٠ص–١٢:٠٠ص\nالجمعة مغلق\nالسبت ١٠:٠٠ص–١٢:٠٠ص\nالأحد ١٠:٠٠ص–١٢:٠٠ص\nالاثنين ١٠:٠٠ص–١٢:٠٠ص"
}
,
    specialties: [],
    contactInfo: {
      phone: { en: "0867838400", ar: "٠٨٦٧٨٣٨٤٠٠" },
      email: ""
    },
    features: []
  },

  // ======= دير مواس (Deir Mawas) =======
  {
    id: "deir_1",
    name: {
      en: "Abo Ali Fried Chicken",
      ar: "أبو علي - دير مواس"
    },
    description: {
      en: "Fried chicken / fast food chain",
      ar: "وجبات دجاج مقلية / وجبات سريعة"
    },
    imageUrl: "assets/images/Abo Ali Fried Chicken.jpg",
    latitude: 27.644351778537846,
    longitude: 30.85822595123684,
    rating: 3.9
,
    reviewCount: 23,
    cuisineType: {
      en: "Fast Food",
      ar: "وجبات سريعة"
    },
    priceRange: {
      en: "Low",
      ar: "منخفض"
    },
   openingHours: {
  en: "Wed: Open 24 hours, Thu: Open 24 hours, Fri: Closed, Sat: Open 24 hours, Sun: Open 24 hours, Mon: Open 24 hours, Tue: Open 24 hours",
  ar: "الأربعاء: نعمل على مدار 24 ساعة، الخميس: نعمل على مدار 24 ساعة، الجمعة: مغلق، السبت: نعمل على مدار 24 ساعة، الأحد: نعمل على مدار 24 ساعة، الاثنين: نعمل على مدار 24 ساعة، الثلاثاء: نعمل على مدار 24 ساعة"
},

    specialties: [
      { en: "Fried Chicken", ar: "دجاج مقلي" }
    ],
    contactInfo: {
     phone: {
  en: "01001436173",
  ar: "٠١٠٠١٤٣٦١٧٣"
},

      email: ""
    },
    features: [
      { en: "Delivery", ar: "توصيل" }
    ]
  },

  // ======= أبو قرقاص (Abu Qurqas) =======
  // {
  //   id: "abuq_1",
  //   name: {
  //     en: "Samihah Restaurant",
  //     ar: "مطعم سميحة"
  //   },
  //   description: {
  //     en: "Local pizza/delivery and family restaurant in Abu Qurqas",
  //     ar: "مطعم بيتزا وتوصيل عائلي في أبو قرقاص"
  //   },
  //   imageUrl: "https://www.yellowpages.com.eg/images/612625.jpg",
  //   latitude: 0,
  //   longitude: 0,
  //   rating: 0,
  //   reviewCount: 0,
  //   cuisineType: {
  //     en: "Pizza / Egyptian",
  //     ar: "بيتزا / مصري"
  //   },
  //   priceRange: {
  //     en: "Low to Mid",
  //     ar: "منخفض إلى متوسط"
  //   },
  //   openingHours: {
  //     en: "",
  //     ar: ""
  //   },
  //   specialties: [
  //     { en: "Pizza", ar: "بيتزا" }
  //   ],
  //   contactInfo: {
  //     phone: { en: "", ar: "" },
  //     email: ""
  //   },
  //   features: [
  //     { en: "Delivery", ar: "توصيل" }
  //   ]
  // },
  {
    id: "abuq_2",
    name: {
      en: "Fritto Burger - Abu Qurqas",
      ar: "فريتو برجر"
    },
    description: {
      en: "Popular local burger chain/fast food listed for Abu Qurqas",
      ar: "سلسلة برجر محلية / وجبات سريعة مدرجة لأبو قرقاص"
    },
    imageUrl: "assets/images/Fritto Burger - Abu Qurqas.jpg",
    latitude: 27.935555521476903, 
    longitude: 30.85822595123684,
    rating: 4.6
,
    reviewCount: 10,
    cuisineType: {
      en: "Fast Food",
      ar: "وجبات سريعة"
    },
    priceRange: {
      en: "Low",
      ar: "منخفض"
    },
   openingHours: {
  en: "Wednesday: 2:00 PM–2:00 AM, Thursday: 2:00 PM–2:00 AM, Friday: Closed, Saturday: 2:00 PM–2:00 AM, Sunday: 2:00 PM–2:00 AM, Monday: 2:00 PM–2:00 AM, Tuesday: 2:00 PM–2:00 AM",
  ar: "الأربعاء: ٢:٠٠م–٢:٠٠ص، الخميس: ٢:٠٠م–٢:٠٠ص، الجمعة: مغلق، السبت: ٢:٠٠م–٢:٠٠ص، الأحد: ٢:٠٠م–٢:٠٠ص، الاثنين: ٢:٠٠م–٢:٠٠ص، الثلاثاء: ٢:٠٠م–٢:٠٠ص"
},

    specialties: [
      { en: "Burgers", ar: "برجر" }
    ],
    contactInfo: {
      phone: { en: "01148263649", ar: "01148263649" },
      email: ""
    },
    features: [
      { en: "Delivery", ar: "توصيل" }
    ]
  },
  {
    id: "abuq_3",
    name: {
      en: "Chef Mayer & Mood's (Abu Qurqas)",
      ar: "شيف ماير ومودز"
    },
    description: {
      en: "Restaurant & drinks — local Abu Qurqas venue (Facebook page)",
      ar: "مطعم ومشروبات — مكان محلي في أبو قرقاص (صفحة فيسبوك)"
    },
    imageUrl: "assets/images/Chef Mayer & Mood's (Abu Qurqas).jpg",
    latitude: 27.936115949277433, 
    longitude: 30.85822595123684,
    rating: 4.3,
    reviewCount:41,
    cuisineType: {
      en: "Mixed",
      ar: "متنوع"
    },
    priceRange: {
      en: "Mid-range",
      ar: "متوسط"
    },
   openingHours: {
  en: "Wed 1:00 PM – 2:00 AM\nThu 1:00 PM – 2:00 AM\nFri 1:00 PM – 2:00 AM\nSat 1:00 PM – 2:00 AM\nSun Closed\nMon 1:00 PM – 2:00 AM",
  ar: "الأربعاء ١:٠٠م–٢:٠٠ص\nالخميس ١:٠٠م–٢:٠٠ص\nالجمعة ١:٠٠م–٢:٠٠ص\nالسبت ١:٠٠م–٢:٠٠ص\nالأحد مغلق\nالاثنين ١:٠٠م–٢:٠٠ص"
}
,
    specialties: [],
    contactInfo: {
       phone: { en: "01282420500", ar: "٠١٢٨٢٤٢٠٥٠٠" },
      email: ""
    },
    features: []
  },

  // ======= سمالوط (Samalut) =======
  {
    id: "sam_1",
    name: {
      en: "Beit ElSham",
      ar: "بيت الشام - سمالوط"
    },
    description: {
      en: "Syrian-style restaurant and shawarma, popular in Samalut",
      ar: "مطعم سوري وشاورما، مشهور في سمالوط"
    },
    imageUrl: "assets/images/Beit ElSham.jpg",
    latitude: 28.312556228503542,
    longitude: 30.70910417266086,
    rating: 3.8
,
    reviewCount:207,
    cuisineType: {
      en: "Syrian / Middle Eastern",
      ar: "سوري / شرق أوسطي"
    },
    priceRange: {
      en: "Low to Mid",
      ar: "منخفض إلى متوسط"
    },
   openingHours: {
  en: "Wed 1:00 PM – 3:00 AM\nThu 1:00 PM – 2:00 AM\nFri 3:00 PM – 3:00 AM\nSat 1:00 PM – 3:00 AM\nSun 1:00 PM – 3:00 AM\nMon 1:00 PM – 3:00 AM",
  ar: "الأربعاء ١:٠٠م–٣:٠٠ص\nالخميس ١:٠٠م–٢:٠٠ص\nالجمعة ٣:٠٠م–٣:٠٠ص\nالسبت ١:٠٠م–٣:٠٠ص\nالأحد ١:٠٠م–٣:٠٠ص\nالاثنين ١:٠٠م–٣:٠٠ص"
},

    specialties: [
      { en: "Shawarma", ar: "شاورما" }
    ],
    contactInfo: {
      phone: { en: "01026879698", ar: "٠١٠٢٦٨٧٩٦٩٨" },
      email: ""
    },
    features: [
      { en: "Takeaway", ar: "تيك أواي" },
      { en: "Delivery", ar: "توصيل" }
    ]
  },
  // {
  //   id: "sam_2",
  //   name: {
  //     en: "Plaza Club - Samalut",
  //     ar: "نادي بلازا - سمالوط"
  //   },
  //   description: {
  //     en: "Local restaurant / club offering casual dining",
  //     ar: "مطعم محلي / نادي يقدم وجبات عادية"
  //   },
  //   imageUrl: "https://mindtrip-ai-images.s3.amazonaws.com/plaza_club_samalut.jpg",
  //   latitude: 0,
  //   longitude: 0,
  //   rating: 0,
  //   reviewCount: 0,
  //   cuisineType: {
  //     en: "Mixed",
  //     ar: "متنوع"
  //   },
  //   priceRange: {
  //     en: "Mid-range",
  //     ar: "متوسط"
  //   },
  //   openingHours: {
  //     en: "",
  //     ar: ""
  //   },
  //   specialties: [],
  //   contactInfo: {
  //     phone: { en: "", ar: "" },
  //     email: ""
  //   },
  //   features: []
  // },

  // ======= مطاي (Matai) =======
  // {
  //   id: "matai_1",
  //   name: {
  //     en: "Local Grills & Koshary - Matai",
  //     ar: "مشاوي و كشري محلي - مطاي"
  //   },
  //   description: {
  //     en: "Several local family restaurants in Matai appear in delivery/directory listings",
  //     ar: "عدة مطاعم عائلية في مطاي تظهر في دلائل التوصيل"
  //   },
  //   imageUrl: "",
  //   latitude: 0,
  //   longitude: 0,
  //   rating: 0,
  //   reviewCount: 0,
  //   cuisineType: {
  //     en: "Egyptian",
  //     ar: "مصري"
  //   },
  //   priceRange: {
  //     en: "Low",
  //     ar: "منخفض"
  //   },
  //   openingHours: {
  //     en: "",
  //     ar: ""
  //   },
  //   specialties: [],
  //   contactInfo: {
  //     phone: { en: "", ar: "" },
  //     email: ""
  //   },
  //   features: []
  // },

  // ======= مغاغة (Maghagha) =======
  // {
  //   id: "mag_1",
  //   name: {
  //     en: "Local restaurants - Maghagha",
  //     ar: "مطاعم محلية - مغاغة"
  //   },
  //   description: {
  //     en: "Maghagha has multiple local restaurants and grills listed on YellowPages and Facebook groups",
  //     ar: "مغاغة تحتوي على عدة مطاعم ومشاوي محلية مدرجة على YellowPages ومجموعات فيسبوك"
  //   },
  //   imageUrl: "",
  //   latitude: 0,
  //   longitude: 0,
  //   rating: 0,
  //   reviewCount: 0,
  //   cuisineType: {
  //     en: "Egyptian",
  //     ar: "مصري"
  //   },
  //   priceRange: {
  //     en: "Low to Mid",
  //     ar: "منخفض إلى متوسط"
  //   },
  //   openingHours: {
  //     en: "",
  //     ar: ""
  //   },
  //   specialties: [],
  //   contactInfo: {
  //     phone: { en: "", ar: "" },
  //     email: ""
  //   },
  //   features: []
  // },

  // ======= العدوة (El Adwa) =======
  // {
  //   id: "adwa_1",
  //   name: {
  //     en: "Local eateries - El Adwa",
  //     ar: "مطاعم محلية - العدوة"
  //   },
  //   description: {
  //     en: "Small local restaurants appear on local directories and Facebook community pages",
  //     ar: "مطاعم صغيرة محلية تظهر على دلائل محلية وصفحات المجتمع على فيسبوك"
  //   },
  //   imageUrl: "",
  //   latitude: 0,
  //   longitude: 0,
  //   rating: 0,
  //   reviewCount: 0,
  //   cuisineType: {
  //     en: "Egyptian",
  //     ar: "مصري"
  //   },
  //   priceRange: {
  //     en: "Low",
  //     ar: "منخفض"
  //   },
  //   openingHours: {
  //     en: "",
  //     ar: ""
  //   },
  //   specialties: [],
  //   contactInfo: {
  //     phone: { en: "", ar: "" },
  //     email: ""
  //   },
  //   features: []
  // }






  // ====== مطاعم مركز المنيا (مجمعة دفعة واحدة) ======

 // دفعة محدثة — مدخَلات متوافقة 1:1 مع نمط الـ object المطلوب
{
  id: "freika_minya",
  name: { en: "Freekeh Restaurant Minya", ar: "مطعم فريكة المنيا" },
  description: { en: "Syrian-style fast food & shawarma; branch on Taha Hussein near Sports Club (New Minya).", ar: "مطبخ سوري وشاورما؛ فرع في شارع طه حسين قرب سور النادي (المنيا الجديدة)." },
  imageUrl: "assets/images/مطعم فريكة.jpg",
  latitude:28.10200304070646,
  longitude:  30.754193601501832,
  rating: 4.0
,
  reviewCount:936,
  cuisineType: { en: "Syrian / Fast Food", ar: "سوري / وجبات سريعة" },
  priceRange: { en: "Low to Mid", ar: "منخفض إلى متوسط" },
  openingHours: { en: "Mon–Sun 10:00 AM – 04:00 AM", ar: "الاثنين–الأحد ١٠:٠٠ ص – ٤:٠٠ ص" },
  specialties: [ { en: "Shawarma", ar: "شاورما" }, { en: "Broasted Chicken", ar: "بروستد" } ],
  contactInfo: { phone: { en: "01030022700, 01555511777, 01128848054", ar: "٠١٠٣٠٠٢٢٧٠٠، ٠١٥٥٥٥١١٧٧٧، ٠١١٢٨٨٤٨٠٥٤" }, email: "" },
  features: [ { en: "Restroom", ar: "دورة مياه" } ],
  imageGallery: [
      "/assets/images/freekeh-restaurant_menu_1.jpg",
       "/assets/images/freekeh-restaurant_menu_2.jpg",
        "/assets/images/freekeh-restaurant_menu_3.jpg",
         "/assets/images/freekeh-restaurant_menu_4.jpg"
  ]
}
,
{
  id: "set_elsham",
  name: { en: "Set El Sham", ar: "ست الشام" },
  description: {
    en: "Popular local restaurant offering Levantine & Egyptian specialties — grills, shawarma and family-style dishes. Busy evenings and late-night service.",
    ar: "مطعم شعبي يقدم أطباق شامية ومصرية مميزة — مشاوي، شاورما وأطباق عائلية. مزدحم مساءً ويقدم خدمة ليلية متأخرة."
  },
  imageUrl: "assets/images/set elsham.png",
  latitude: 28.1070,
  longitude: 30.7500,
  rating: 4.1,
  reviewCount: 1779,
  cuisineType: { en: "Levantine / Egyptian", ar: "شامي / مصري" },
  priceRange: { en: "Low to Mid", ar: "منخفض إلى متوسط" },
  openingHours: {
    en:
      "Mon 11:00 AM – 02:00 AM\nTue 11:00 AM – 02:00 AM\nWed 11:00 AM – 02:00 AM\nThu 11:00 AM – 03:00 AM\nFri 01:00 PM – 03:00 AM\nSat 11:00 AM – 02:00 AM\nSun 11:00 AM – 02:00 AM",
    ar:
      "الاثنين ١١:٠٠ص–٢:٠٠ص\nالثلاثاء ١١:٠٠ص–٢:٠٠ص\nالأربعاء ١١:٠٠ص–٢:٠٠ص\nالخميس ١١:٠٠ص–٣:٠٠ص\nالجمعة ١:٠٠م–٣:٠٠ص\nالسبت ١١:٠٠ص–٢:٠٠ص\nالأحد ١١:٠٠ص–٢:٠٠ص"
  },
  specialties: [
    { en: "Grills", ar: "مشاوي" },
    { en: "Shawarma", ar: "شاورما" },
    { en: "Family dishes", ar: "أطباق عائلية" }
  ],
  contactInfo: {
    phone: { en: "01060601600", ar: "٠١٠٦٠٦٠١٦٠٠" },
    email: ""
  },
  features: [
    { en: "Delivery", ar: "توصيل" },
    { en: "Indoor seating", ar: "جلسات داخلية" },
    { en: "Late-night service", ar: "خدمة ليلية" }
  ],
  imageGallery: [
    "assets/images/ست الشام المنيا.jpg",
    "assets/images/images (2).jpg",
    
  ]
}

,


{
  id: "fresh_food_grills_minya",
  name: { en: "Fresh Food Grills", ar: "مطعم مشويات فريش فوود" },
  description: {
    en: "Grill restaurant offering mixed grills, kebabs and family platters. Popular for evening dining and group meals in New Minya.",
    ar: "مطعم مشويات يقدم مشاوي متنوعة، كفتة وأسياخ وأطباق عائلية. شائع للعزومات والسهرات في مدينة المنيا الجديدة."
  },
  imageUrl: "assets/images/2021-08-28.png",
  // إحداثيات تقريبية لمدينة المنيا الجديدة — أرسلي إحداثيات دقيقة لو حابة
  latitude: 28.1060,
  longitude: 30.7510,
  rating: 4.7,
  reviewCount: 448,
  cuisineType: { en: "Grill / Egyptian", ar: "مشاوي / مصري" },
  priceRange: { en: "Low to Mid", ar: "منخفض إلى متوسط" },
  openingHours: {
    en:
      "Mon 11:30 AM – 03:00 AM\nTue 11:30 AM – 03:00 AM\nWed 11:30 AM – 03:00 AM\nThu 11:30 AM – 03:00 AM\nFri 01:00 PM – 03:00 AM\nSat 11:30 AM – 03:00 AM\nSun 11:30 AM – 03:00 AM",
    ar:
      "الاثنين ١١:٣٠ص–٣:٠٠ص\nالثلاثاء ١١:٣٠ص–٣:٠٠ص\nالأربعاء ١١:٣٠ص–٣:٠٠ص\nالخميس ١١:٣٠ص–٣:٠٠ص\nالجمعة ١:٠٠م–٣:٠٠ص\nالسبت ١١:٣٠ص–٣:٠٠ص\nالأحد ١١:٣٠ص–٣:٠٠ص"
  },
  specialties: [
    { en: "Mixed Grills", ar: "مشاوي مشكلة" },
    { en: "Kebab & Skewers", ar: "كباب وأسياخ" },
    { en: "Family Platters", ar: "أطباق عائلية" }
  ],
  center: { en: "New Minya", ar: "المنيا الجديدة" },
  menu: [], // املئي لاحقاً بـ MenuItem[]
  menuUrl: undefined,
  contactInfo: {
    phone: { en: "01020004495", ar: "٠١٠ ٢٠٠٠٤٤٩٥" },
    email: ""
  },
  features: [
    { en: "Delivery", ar: "توصيل" },
    { en: "Outdoor seating", ar: "جلسات خارجية" },
    { en: "Late-night service", ar: "خدمة ليلية" }
  ],
   imageGallery: [
    "assets/images/2025-05-21.png",
    // "assets/images/set-elsham_2.jpg",
    // "assets/images/set-elsham_3.jpg"
  ]
  // address: {
  //   en: "Dina, New Minya, Minya Governorate 2460370",
  //   ar: "دينة، المنيا الجديدة، محافظة المنيا 2460370"
  // }
}
,
// {
//   id: "al_mohamady_minya",
//   name: { en: "Al Mohamady Restaurant", ar: "مطعم المحمدى" },
//   description: {
//     en: "Traditional local restaurant in Hasib, serving Egyptian home-style dishes and grills. Known for steady local crowd and long opening hours.",
//     ar: "مطعم محلي في حسيب يقدم أطباق مصرية منزلية ومشاوي. معروف بإقبال محلي وساعات عمل طويلة."
//   },
//   imageUrl: "assets/images/al-mohamady.jpg",
//   latitude: 28.0950,     // تقريبية — أرسلي إحداثيات دقيقة لو حابة
//   longitude: 30.7620,    // تقريبية
//   rating: 3.9,
//   reviewCount: 1983,
//   cuisineType: { en: "Egyptian / Grill", ar: "مصري / مشاوي" },
//   priceRange: { en: "Low", ar: "منخفض" },
//   openingHours: {
//     en:
//       "Mon 08:00 AM – 04:00 AM\nTue 08:00 AM – 04:00 AM\nWed 08:00 AM – 04:00 AM\nThu 08:00 AM – 04:00 AM\nFri 08:00 AM – 04:00 AM\nSat 08:00 AM – 04:00 AM\nSun 08:00 AM – 04:00 AM",
//     ar:
//       "الاثنين ٨:٠٠ص–٤:٠٠ص\nالثلاثاء ٨:٠٠ص–٤:٠٠ص\nالأربعاء ٨:٠٠ص–٤:٠٠ص\nالخميس ٨:٠٠ص–٤:٠٠ص\nالجمعة ٨:٠٠ص–٤:٠٠ص\nالسبت ٨:٠٠ص–٤:٠٠ص\nالأحد ٨:٠٠ص–٤:٠٠ص"
//   },
//   specialties: [
//     { en: "Grills", ar: "مشاوي" },
//     { en: "Home-style stews", ar: "طواجن وأكلات منزلية" },
//     { en: "Breakfast (early)", ar: "فطار مبكر" }
//   ],
//   center: { en: "Hasib / Minya Center", ar: "حسيب / مركز المنيا" },
//   menu: [], // املئي بـ MenuItem[] لاحقاً إذا حابة
//   menuUrl: undefined,
//   contactInfo: {
//     phone: { en: "0862359696", ar: "٠٨٦ ٢٣٥٩٦٩٦" },
//     email: ""
//   },
//   features: [
//     { en: "Takeaway", ar: "طلبات خارجية" },
//     { en: "Outdoor seating", ar: "جلسات خارجية" },
//     { en: "Late-night service", ar: "خدمة ليلية" }
//   ],
//   address: {
//     en: "Hasib, Minya District, Minya Governorate 2451113",
//     ar: "حسيب، قسم المنيا، مركز المنيا، محافظة المنيا 2451113"
//   }
// },
{
  id: "al_mohamady_minya",
  name: { en: "Al Mohamady Restaurant", ar: "مطعم المحمدى" },
  description: {
    en: "Traditional local restaurant in Hasib, serving Egyptian home-style dishes and grills. Known for steady local crowd and long opening hours.",
    ar: "مطعم محلي في حسيب يقدم أطباق مصرية منزلية ومشاوي. معروف بإقبال محلي وساعات عمل طويلة."
  },
  imageUrl: "assets/images/unnamed (1).png",
  latitude: 28.0950,     // تقريبية — أرسلي إحداثيات دقيقة لو حابة
  longitude: 30.7620,    // تقريبية
  rating: 3.9,
  reviewCount: 1983,
  cuisineType: { en: "Egyptian / Grill", ar: "مصري / مشاوي" },
  priceRange: { en: "Low", ar: "منخفض" },
  openingHours: {
    en:
      "Mon 08:00 AM – 04:00 AM\nTue 08:00 AM – 04:00 AM\nWed 08:00 AM – 04:00 AM\nThu 08:00 AM – 04:00 AM\nFri 08:00 AM – 04:00 AM\nSat 08:00 AM – 04:00 AM\nSun 08:00 AM – 04:00 AM",
    ar:
      "الاثنين ٨:٠٠ص–٤:٠٠ص\nالثلاثاء ٨:٠٠ص–٤:٠٠ص\nالأربعاء ٨:٠٠ص–٤:٠٠ص\nالخميس ٨:٠٠ص–٤:٠٠ص\nالجمعة ٨:٠٠ص–٤:٠٠ص\nالسبت ٨:٠٠ص–٤:٠٠ص\nالأحد ٨:٠٠ص–٤:٠٠ص"
  },
  specialties: [
    { en: "Grills", ar: "مشاوي" },
    { en: "Home-style stews", ar: "طواجن وأكلات منزلية" },
    { en: "Breakfast (early)", ar: "فطار مبكر" }
  ],
  center: { en: "Hasib / Minya Center", ar: "حسيب / مركز المنيا" },
  menu: [], // املئي بـ MenuItem[] لاحقاً إذا حابة
  menuUrl: undefined,
  contactInfo: {
    phone: { en: "0862359696", ar: "٠٨٦ ٢٣٥٩٦٩٦" },
    email: ""
  },
  features: [
    { en: "Takeaway", ar: "طلبات خارجية" },
    { en: "Outdoor seating", ar: "جلسات خارجية" },
    { en: "Late-night service", ar: "خدمة ليلية" }
  ],
  imageGallery: [
    "assets/images/unnamed (4).png"
  ],
  address: {
    en: "Hasib, Minya District, Minya Governorate 2451113",
    ar: "حسيب، قسم المنيا، مركز المنيا، محافظة المنيا 2451113"
  }
}
,
{
  id: "city_crepe_minya",
  name: { en: "City Crepe", ar: "سيتي كريب" },
  description: {
    en: "Small creperie offering sweet & savory crepes, coffee and light snacks. Located in Old Minya — see address below.",
    ar: "كريب صغير يقدم كريب حلو ومالح، قهوة وسناكات خفيفة. يقع في أول المنيا — العنوان أسفل."
  },
  imageUrl: "assets/images/City crepe.png",
  // تقريبياً مركز المدينة (استخدمّي إحداثيات دقيقة إذا عندك)
  latitude: 28.0970,
  longitude: 30.7610,
  rating: 3.5,
  reviewCount: 122,
  cuisineType: { en: "Crepes / Cafe", ar: "كريب / مقهى" },
  priceRange: { en: "Low", ar: "منخفض" },
  openingHours: {
    en: "", // لم تُزود ساعات العمل — اتركيه فارغاً أو ضعي ساعات مقترحة
    ar: ""
  },
  specialties: [
    { en: "Sweet Crepes", ar: "كريب حلو" },
    { en: "Savory Crepes", ar: "كريب مالح" },
    { en: "Coffee & Drinks", ar: "قهوة ومشروبات" }
  ],
  center: { en: "Old Minya", ar: "أول المنيا" },
  menu: [], // اضافة عناصر المينيو لاحقاً كـ MenuItem[]
  menuUrl: undefined,
  contactInfo: {
    phone: { en: "01099258903", ar: "٠١٠٩٩٢٥٨٩٠٣" },
    email: ""
  },
  features: [
    { en: "Takeaway", ar: "طلبات خارجية" },
    { en: "Indoor seating", ar: "جلسات داخلية" }
  ],
   imageGallery: [
    "assets/images/city-crepe_menu_1.jpg",
    "assets/images/city-crepe_menu_2.jpg",
    "assets/images/city-crepe_menu_3.jpg"
  ],
  // إضافة الحقل الوصفي للعنوان الكامل (اختياري — ليس جزءًا من الواجهة الأساسية)
  address: {
    en: "4Q52+337, No. 14, Minya District, Old Minya, Minya Governorate 2451136",
    ar: "4Q52+337، رقم 14، قسم المنيا، أول المنيا، محافظة المنيا 2451136"
  }
}

// مصادر: Menuegypt / Elmenus / Evendo. :contentReference[oaicite:0]{index=0}

,
{
  id: "bondokah_minya",
  name: { en: "Bondokah Restaurant", ar: "مطعم بندقة" },
  description: { en: "Casual grill house known across Minya; serves koshary at some branches.", ar: "مطعم مشاوي شعبي وله فروع بالمنيا؛ يقدم كشري أحيانًا في بعض الفروع." },
  imageUrl: "assets/images/Bondokah Restaurant.jpg",
   latitude: 28.102050188865025, 
    longitude: 30.754808388008396,
    rating: 3.8,
    reviewCount: 2458,
  cuisineType: { en: "Egyptian / Grill", ar: "مصري / مشاوي" },
  priceRange: { en: "Affordable", ar: "مناسب" },
  openingHours: { en: "11:00 AM – 03:00 AM (approx.)", ar: "١١:٠٠ ص – ٠٣:٠٠ ص (تقريبى)" },
  specialties: [ { en: "Mixed Grill", ar: "مشويات مشكلة" }, { en: "Koshary (some branches)", ar: "كشري (بعض الفروع)" } ],
  contactInfo: { phone: { en: "+20 86 2334141 / 01030800072 / 01030800073", ar: "+٢٠ ٨٦ ٢٣٣٤١٤١ / ٠١٠٣٠٨٠٠٠٧٢ / ٠١٠٣٠٨٠٠٠٧٣" }, email: "" },
  features: [ { en: "Restroom", ar: "دورة مياه" }, { en: "Delivery", ar: "توصيل" } ],
  imageGallery: [
      "/assets/images/470498594_933892548838992_4009911687513985324_n (1).jpg"
  ]
}
// مصادر: الموقع الرسمي / صفحة فيسبوك / دلائل محلية. :contentReference[oaicite:1]{index=1}

,
{
  id: "fresh_food_grill",
  name: { en: "Fresh Food Grill Restaurant", ar: "مطعم فريش فود جريل" },
  description: { en: "Mediterranean & Egyptian grilled dishes; listed on TripAdvisor and local directories.", ar: "أطباق مشوية متوسّطية ومصرية؛ مذكور في TripAdvisor وقوائم محلية." },
  imageUrl: "assets/images/Fresh Food Grill Restaurant_n.jpg",

 latitude: 28.07367330527575, 
    longitude: 30.816348988009075,
    rating: 4.7,
    reviewCount: 448,
  cuisineType: { en: "Mediterranean / Grill", ar: "متوسطي / مشاوي" },
  priceRange: { en: "Mid-range", ar: "متوسط" },
  openingHours: { en: "12:00 PM – 01:00 AM", ar: "١٢:٠٠ م – ٠١:٠٠ ص" },
  specialties: [ { en: "Mixed Grill", ar: "مشويات مشكلة" }, { en: "Seafood platters", ar: "أطباق سي فود" } ],
  contactInfo: { phone: { en: "+20 102 000 4495, 01027020307", ar: "+٢٠ ١٠٢ ٠٠٠ ٤٤٩٥، ٠١٠٢٧٠٢٠٣٠٧" }, email: "" },
  features: [ { en: "Restroom", ar: "دورة مياه" }, { en: "Delivery", ar: "توصيل" } ],
  imageGallery: [
      "/assets/images/470498594_933892548838992_4009911687513985324_n (1).jpg"
  ]
}
// مصدر: TripAdvisor، دلائل محلية. :contentReference[oaicite:2]{index=2}

// ,
// {
//   id: "toscanini_minya",
//   name: { en: "Toscanini", ar: "توسكاني" },
//   description: { en: "Italian / mixed cuisine with Nile view (Corniche area / above sports club).", ar: "مطبخ إيطالي ومتنوّع مع إطلالة قرب كورنيش النيل ودور نادي المنيا." },
//   imageUrl: "assets/images/توسكاني.jpg",
//   latitude: 0,
//   longitude: 0,
//   rating: 4.5,
//   reviewCount: 2,
//   cuisineType: { en: "Italian, Mixed", ar: "إيطالي، مختلط" },
//   priceRange: { en: "Mid-range", ar: "متوسط" },
//   openingHours: { en: "12:00 PM – 11:00 PM", ar: "١٢:٠٠ م – ١١:٠٠ م" },
//   specialties: [ { en: "Pasta", ar: "معكرونة" }, { en: "Pizza", ar: "بيتزا" } ],
//   contactInfo: { phone: { en: "+20 127 272 7220", ar: "+٢٠ ١٢٧ ٢٧٢ ٧٢٢٠" }, email: "" },
//   features: [ { en: "Restroom", ar: "دورة مياه" }, { en: "Nile View", ar: "إطلالة على النيل" } ]
// }
// مصدر: TripAdvisor + دلائل محلية. :contentReference[oaicite:3]{index=3}

,
{
  id: "cboat_minya",
  name: { en: "C-Boat", ar: "C-Boat" },
  description: { en: "Nile-side restaurant with views; evening dining spot in Minya.", ar: "مطعم على ضفاف النيل مع إطلالة؛ وجهة شائعة للعشاء في المنيا." },
  imageUrl: "assets/images/hotels/c-boat/c-boat3.jpg",
  latitude: 28.102192108605227,
  longitude: 30.758244263146523,
  rating: 4.1,
  reviewCount: 802,
  cuisineType: { en: "Egyptian / Seafood", ar: "مصري / سي فود" },
  priceRange: { en: "Mid-range", ar: "متوسط" },
  openingHours: {
  en: "Wed 8:00 AM – 11:45 PM\nThu 8:00 AM – 11:45 PM\nFri 8:00 AM – 11:45 PM\nSat 8:00 AM – 11:45 PM\nSun 8:00 AM – 11:45 PM\nMon 8:00 AM – 11:45 PM\nTue 8:00 AM – 11:45 PM",
  ar: "الأربعاء ٨:٠٠ص–١١:٤٥م\nالخميس ٨:٠٠ص–١١:٤٥م\nالجمعة ٨:٠٠ص–١١:٤٥م\nالسبت ٨:٠٠ص–١١:٤٥م\nالأحد ٨:٠٠ص–١١:٤٥م\nالاثنين ٨:٠٠ص–١١:٤٥م\nالثلاثاء ٨:٠٠ص–١١:٤٥م"
},

  specialties: [ { en: "Grilled Fish", ar: "سمك مشوي" } ],
  contactInfo: { phone: { en: "", ar: "" }, email: "" },
  features: [ { en: "Nile View", ar: "إطلالة على النيل" }, { en: "Restroom", ar: "دورة مياه" } ],
  imageGallery: [
      "/assets/images/menu 11.png",
      "/assets/images/menu 14.png",
      "/assets/images/menu 13 (2).png",
       "/assets/images/menu 6.png",
        "/assets/images/menu 18.png",
         "/assets/images/menu 7.png",
          "/assets/images/menu 17.png",
           "/assets/images/menu 3.png",
            "/assets/images/menu 10.png",
             "/assets/images/menu 8.png",
              "/assets/images/menu 4.png",
              "/assets/images/menu 12.png",
              "/assets/images/menu 9.png",
               "/assets/images/menu 5.png",
               "/assets/images/menu 2 (1).png",
                "/assets/images/menu 15.png",
                     "/assets/images/menu 16.png",




  ]
},
// مصاد
// ر: Evendo / CEOSS listing / صفحات محلية. :contentReference[oaicite:4]{index=4}
{
  id: "casa_bella_minya",
  name: { en: "Casa Bella Restaurant", ar: "كازا بيلا" },
  description: {
    en: "Casual restaurant offering Italian-inspired dishes, pizzas and a selection of desserts — popular for family dinners and weekend outings in Old Minya.",
    ar: "مطعم كاجوال يقدم أطباق إيطالية، بيتزا ومجموعة حلويات — مشهور للعزومات العائلية ونهايات الأسبوع في أول المنيا."
  },
  imageUrl: "assets/images/unnamed (5).png",
  // إحداثيات تقريبية لحي طه حسين / أول المنيا — أرسلي إحداثيات دقيقة إن أحببتِ
  latitude: 28.0975,
  longitude: 30.7605,
  rating: 4.4,
  reviewCount: 414,
  cuisineType: { en: "Italian / Pizza / Mediterranean", ar: "إيطالي / بيتزا / متوسطي" },
  priceRange: { en: "Mid", ar: "متوسط" },
  openingHours: {
    en:
      "Mon 10:00 AM – 02:00 AM\nTue 10:00 AM – 02:00 AM\nWed 10:00 AM – 02:00 AM\nThu 10:00 AM – 02:00 AM\nFri 10:00 AM – 02:00 AM\nSat 10:00 AM – 02:00 AM\nSun 10:00 AM – 02:00 AM",
    ar:
      "الاثنين ١٠:٠٠ص–٢:٠٠ص\nالثلاثاء ١٠:٠٠ص–٢:٠٠ص\nالأربعاء ١٠:٠٠ص–٢:٠٠ص\nالخميس ١٠:٠٠ص–٢:٠٠ص\nالجمعة ١٠:٠٠ص–٢:٠٠ص\nالسبت ١٠:٠٠ص–٢:٠٠ص\nالأحد ١٠:٠٠ص–٢:٠٠ص"
  },
  specialties: [
    { en: "Pizza", ar: "بيتزا" },
    { en: "Pasta", ar: "باستا" },
    { en: "Desserts", ar: "حلويات" }
  ],
  center: { en: "Taha Hussein / Old Minya", ar: "طه حسين / أول المنيا" },
  menu: [], // ضيفي MenuItem[] لاحقاً لو حابة
  menuUrl: undefined,
  contactInfo: {
    phone: { en: "01003397905", ar: "٠١٠ ٠٣٣٩٧٩٠٥" },
    email: ""
  },
  features: [
    { en: "Indoor seating", ar: "جلسات داخلية" },
    { en: "Family friendly", ar: "مناسب للعائلات" },
    { en: "Takeaway", ar: "طلبات خارجية" }
  ],
   imageGallery: [
      "/assets/images/131098693_2747922352140036_7804884136602912632_o.png",
     




  ]
  // address: {
  //   en: "Taha Hussein, Minya District, Old Minya, Minya Governorate 2451140",
  //   ar: "طه حسين، قسم المنيا، أول المنيا، محافظة المنيا 2451140"
  // }
}

,
{
  id: "casa_bella_minya",
  name: { en: "Casa Bella Restaurant", ar: "كازا بيلا" },
  description: { en: "Italian & mixed menu; local listings show menu and phone for New Minya branch.", ar: "قائمة إيطالية ومتنوعة؛ القوائم المحلية تعرض المنيو ورقم الفرع بالمنيا الجديدة." },
  imageUrl: "assets/images/casa_bella_minya.jpg",
  latitude:28.109110928333763,  longitude:  30.751969259024474,

  rating: 4.4
,
  reviewCount:414,
  cuisineType: { en: "Italian / Mixed", ar: "إيطالي / متنوع" },
  priceRange: { en: "Mid-range", ar: "متوسط" },
 openingHours: {
  en: "Wed 10:00 AM – 2:00 AM\nThu 10:00 AM – 2:00 AM\nFri 10:00 AM – 2:00 AM\nSat 10:00 AM – 2:00 AM\nSun 10:00 AM – 2:00 AM\nMon 10:00 AM – 2:00 AM\nTue 10:00 AM – 2:00 AM",
  ar: "الأربعاء ١٠:٠٠ص–٢:٠٠ص\nالخميس ١٠:٠٠ص–٢:٠٠ص\nالجمعة ١٠:٠٠ص–٢:٠٠ص\nالسبت ١٠:٠٠ص–٢:٠٠ص\nالأحد ١٠:٠٠ص–٢:٠٠ص\nالاثنين ١٠:٠٠ص–٢:٠٠ص\nالثلاثاء ١٠:٠٠ص–٢:٠٠ص"
},

  specialties: [ { en: "Pizza", ar: "بيتزا" }, { en: "Pasta", ar: "باستا" } ],
  contactInfo: { phone: { en: "01003397905, 01018101015", ar: "٠١٠٠٣٣٩٧٩٠٥، ٠١٠١٨١٠١٠١٥" }, email: "" },
  features: [ { en: "Restroom", ar: "دورة مياه" } ],
  imageGallery: [
      "/assets/images/470498594_933892548838992_4009911687513985324_n (1).jpg"
  ]
}
// مصدر: دلائل محلية (Menuegypt, elmenus). :contentReference[oaicite:5]{index=5}

,
{
  id: "el_baron_minya",
  name: { en: "El Baron", ar: "البارون" },
  description: { en: "Upper-floor dining near Teachers Union Tower; mixed menu and evening hours.", ar: "مطعم بالدور العلوي قرب برج نقابة المعلمين؛ قائمة متنوّعة وساعات مسائية." },
  imageUrl: "assets/images/unnamed.jpg",
  latitude:28.095285283199047,
  longitude:  30.7558151846579,
  rating: 4.1,
  reviewCount:295,
  cuisineType: { en: "Mixed", ar: "متنوع" },
  priceRange: { en: "Mid-range", ar: "متوسط" },
  openingHours: {
  en: "Sun Open 24 hours\nMon Open 24 hours\nTue Open 24 hours\nWed Open 24 hours\nThu Open 24 hours\nFri Open 24 hours\nSat Open 24 hours",
  ar: "الأحد نعمل على مدار 24 ساعة\nالاثنين نعمل على مدار 24 ساعة\nالثلاثاء نعمل على مدار 24 ساعة\nالأربعاء نعمل على مدار 24 ساعة\nالخميس نعمل على مدار 24 ساعة\nالجمعة نعمل على مدار 24 ساعة\nالسبت نعمل على مدار 24 ساعة"
},
   imageGallery: [
      "/assets/images/470498594_933892548838992_4009911687513985324_n (1).jpg",
     

    ],

 specialties: [
    { en: "Grilled Fish", ar: "سمك مشوي" },
    { en: "Seafood Platter", ar: "طبق سي فود" },
    { en: "Breakfast & Brunch", ar: "فطار وبرانش" },
    { en: "Event Catering / Banquets", ar: "تموين حفلات / قاعات" }
  ],
  contactInfo: { phone: { en: "0862334667, 01022998668, 01125654501", ar: "٠٨٦٢٣٣٤٦٦٧، ٠١٠٢٢٩٩٨٦٦٨، ٠١١٢٥٦٥٤٥٠١" }, email: "" },
  features: [ { en: "Restroom", ar: "دورة مياه" } ]
},
// ومصدر: دلائل محلية وTripAdvisor. :contentReference[oaicite:6]{index=6}




{
  id: "eltabei_minya",
  name: { en: "El Tabai", ar: "التابعي" },
  description: {
    en: "Serving traditional Egyptian street food and sandwiches around the clock.",
    ar: "نقدّم أشهى المأكولات الشعبية وجميع أنواع السندوتشات على مدار الساعة."
  },
  imageUrl: "assets/images/unnamed (2).png",
  latitude: 28.086694,
  longitude: 30.763122,
  rating: 3.9,
  reviewCount: 149,
  cuisineType: { en: "Egyptian Street Food", ar: "مأكولات شعبية" },
  priceRange: { en: "1–100 E£ per person", ar: "١–١٠٠ جنيه للفرد" },
  openingHours: {
    en: "Sun Open 24 hours\nMon Open 24 hours\nTue Open 24 hours\nWed Open 24 hours\nThu Open 24 hours\nFri Open 24 hours\nSat Open 24 hours",
    ar: "الأحد نعمل على مدار 24 ساعة\nالاثنين نعمل على مدار 24 ساعة\nالثلاثاء نعمل على مدار 24 ساعة\nالأربعاء نعمل على مدار 24 ساعة\nالخميس نعمل على مدار 24 ساعة\nالجمعة نعمل على مدار 24 ساعة\nالسبت نعمل على مدار 24 ساعة"
  },
  imageGallery: [
    "assets/images/images (1).jpg",
    
  ],
  specialties: [
    { en: "Egyptian Sandwiches", ar: "سندوتشات مصرية" },
    { en: "Falafel & Beans", ar: "فلافل وفول" },
    { en: "Traditional Dishes", ar: "وجبات شعبية تقليدية" }
  ],
  contactInfo: {
    phone: { en: "01555724861", ar: "٠١٥٥٥٧٢٤٨٦١" },
    email: ""
  },
  features: [
    { en: "Cash only", ar: "الدفع نقدي فقط" },
    { en: "No reservations", ar: "لا يقبل الحجوزات" },
    { en: "Vegan options", ar: "خيارات خالية من المنتجات الحيوانية" },
    { en: "Open 24 hours", ar: "يعمل على مدار الساعة" }
  ]
}

,
{
  id: "orchid_palace_minya",
  name: { en: "Orchid Palace", ar: "قصر الاوركيد" },
  description: { en: "Large Nile-side restaurant & events venue; outdoor seating & seafood specialties.", ar: "مطعم كبير على النيل ومكان فعاليات؛ جلسات خارجية وتخصصات بحرية." },
  imageUrl: "assets/images/orchid_palace_minya.jpg",
  latitude: 28.107475956014888, 
  longitude:30.753097126986848,
  rating: 3.6,
  reviewCount:51,
  cuisineType: { en: "Mixed / Seafood", ar: "متنوع / أسماك" },
  priceRange: { en: "Mid-range to High", ar: "متوسط إلى مرتفع" },
  openingHours: { en: "10:00 AM – 12:00 AM (varies)", ar: "١٠:٠٠ ص – ١٢:٠٠ ص (متغير)" },
  specialties: [ { en: "Seafood", ar: "أسماك" }, { en: "Events & Banquets", ar: "حفلات ومناسبات" } ],
  contactInfo: { phone: { en: "01555544433, 01000239239", ar: "٠١٥٥٥٥٤٤٤٣٣، ٠١٠٠٠٢٣٩٢٣٩" }, email: "" },
  features: [ { en: "Nile View", ar: "إطلالة على النيل" }, { en: "Restroom", ar: "دورة مياه" } ]
}
// مصادر: Evendo / دلائل محلية / صفحات المؤسسة. :contentReference[oaicite:7]{index=7}

,

  {
  id: "alkasrawy_minya",
  name: { en: "Al-Kasrawy", ar: "الكسراوى" },
  description: {
    en: "Popular crepes, pizzas and mixed grill spot in Minya (local branch posts and menu on Facebook).",
    ar: "مطعم يقدم كريب، بيتزا ومشاوي؛ مشهور محليًا وله منشورات وقوائم على صفحة فيسبوك."
  },
  imageUrl: "assets/images/alkasrawy_minya.jpg",
  latitude: 28.09405459419683, 
  longitude: 30.758448103350602,
  rating:4.1
,
  reviewCount: 10,
  cuisineType: { en: "Crepes / Pizza / Grill", ar: "كريب / بيتزا / مشاوي" },
  priceRange: { en: "Low to Mid", ar: "منخفض إلى متوسط" },
openingHours: {
  en: "Wed 12:00 PM – 2:00 AM\nThu 12:00 PM – 2:00 AM\nFri 12:00 PM – 2:00 AM\nSat 12:00 PM – 2:00 AM\nSun 12:00 PM – 2:00 AM\nMon 12:00 PM – 2:00 AM\nTue 12:00 PM – 2:00 AM",
  ar: "الأربعاء ١٢:٠٠م–٢:٠٠ص\nالخميس ١٢:٠٠م–٢:٠٠ص\nالجمعة ١٢:٠٠م–٢:٠٠ص\nالسبت ١٢:٠٠م–٢:٠٠ص\nالأحد ١٢:٠٠م–٢:٠٠ص\nالاثنين ١٢:٠٠م–٢:٠٠ص\nالثلاثاء ١٢:٠٠م–٢:٠٠ص"
}
,
  specialties: [
    { en: "Crepes", ar: "كريب" },
    { en: "Stone-baked Pizza", ar: "بيتزا حجرية" },
    { en: "Mixed Grill", ar: "مشويات مشكلة" },
    { en: "Desserts", ar: "حلويات" }
  ],
  contactInfo: { phone: { en: "01004875750, 01220074479", ar: "٠١٠٠٤٨٧٥٧٥٠، ٠١٢٢٠٠٧٤٤٧٩" }, email: "" },
  features: [
     { en: "Restroom", ar: "دورة مياه" },
    { en: "Delivery", ar: "توصيل" },
    { en: "Takeaway", ar: "تيك أواي" }
  ],

},
 
{
  id: "festival_crepiano_minya",
  name: { en: "Festival Crepiano", ar: "Festival Crepiano" },
  description: { en: "Crepes, desserts and fast casual — active branch in Minya with delivery and hotline numbers.", ar: "كريب وحلويات وسريع؛ فرع نشط بالمنيا مع أرقام توصيل وخط ساخن." },
  imageUrl: "assets/images/f.jpg",
  latitude:28.10036480864857, 
  longitude:30.75511633218607,
  rating: 3.9,
  reviewCount: 36,
  cuisineType: { en: "Crepes / Desserts", ar: "كريب / حلويات" },
  priceRange: { en: "Low to Mid", ar: "منخفض إلى متوسط" },
 openingHours: {
    en: "Wed 8:00 AM – 10:00 PM\nThu 8:00 AM – 10:00 PM\nFri 8:00 AM – 10:00 PM\nSat 8:00 AM – 10:00 PM\nSun 8:00 AM – 10:00 PM\nMon 8:00 AM – 10:00 PM\nTue 8:00 AM – 10:00 PM",
    ar: "الأربعاء ٨:٠٠ص–١٠:٠٠م\nالخميس ٨:٠٠ص–١٠:٠٠م\nالجمعة ٨:٠٠ص–١٠:٠٠م\nالسبت ٨:٠٠ص–١٠:٠٠م\nالأحد ٨:٠٠ص–١٠:٠٠م\nالاثنين ٨:٠٠ص–١٠:٠٠م\nالثلاثاء ٨:٠٠ص–١٠:٠٠م"
  },
 specialties: [
    { en: "Filled Crepes (savory & sweet)", ar: "كريب محشو (مالح وحلو)" },
    { en: "Stone-baked Pizza", ar: "بيتزا حجرية" },
    { en: "Chicken Sandwiches & Shawarma", ar: "سندوتشات فراخ وشاورما" },
    { en: "Desserts & Pastries", ar: "حلويات وفطائر" }
  ],
  contactInfo: { phone: { en: "01013739999, 01159454820, 0862375444", ar: "٠١٠١٣٧٣٩٩٩٩، ٠١١٥٩٤٥٤٨٢٠، ٠٨٦٢٣٧٥٤٤٤" }, email: "" },
   features: [
    { en: "Delivery", ar: "توصيل" },
    { en: "Takeaway", ar: "تيك أواي" },
    { en: "Online Ordering (Talabat)", ar: "توصيل أونلاين (طلبات)" }
  ]

},
  
 {
  id: "house_crepe_minya",
  name: { en: "House Crepe", ar: "House Crepe" },
  description: { en: "Crepes & cafe branch in New Minya — menu and contact listed on Elmenus.", ar: "فرع كريب وكافيه بالمنيا الجديدة؛ المنيو ورقم التوصيل مذكورين في Elmenus." },
  imageUrl: "assets/images/house_crepe_minya.jpg",
  latitude: 28.108783632707468,
  longitude:  30.749385289856875,
  rating: 3.9
,
  reviewCount:134,
  cuisineType: { en: "Crepes / Cafe", ar: "كريب / كافيه" },
  priceRange: { en: "Low to Mid", ar: "منخفض إلى متوسط" },
   openingHours: {
    en: "Wed 8:00 AM – 2:00 AM\nThu 8:00 AM – 2:00 AM\nFri 8:00 AM – 2:00 AM\nSat 8:00 AM – 2:00 AM\nSun 8:00 AM – 2:00 AM\nMon 8:00 AM – 2:00 AM\nTue 8:00 AM – 2:00 AM",
    ar: "الأربعاء ٨:٠٠ص–٢:٠٠ص\nالخميس ٨:٠٠ص–٢:٠٠ص\nالجمعة ٨:٠٠ص–٢:٠٠ص\nالسبت ٨:٠٠ص–٢:٠٠ص\nالأحد ٨:٠٠ص–٢:٠٠ص\nالاثنين ٨:٠٠ص–٢:٠٠ص\nالثلاثاء ٨:٠٠ص–٢:٠٠ص"
  },
  specialties: [
    { en: "Filled Crepes (savory & sweet)", ar: "كريب محشو (مالح وحلو)" },
    { en: "Pizza & Pasta", ar: "بيتزا ومعكرونة" },
    { en: "Sandwiches & Wraps", ar: "سندوتشات ولفائف" },
    { en: "Desserts & Pastries", ar: "حلويات وفطائر" }
  ],
  contactInfo: { phone: { en: "086 236 2252", ar: "٠٨٦ ٢٣٦ ٢٢٥٢" }, email: "" },
   features: [
    { en: "Delivery", ar: "توصيل" },
    { en: "Takeaway", ar: "تيك أواي" },
    { en: "Restroom", ar: "دورة مياه" }
  ]

},

// {
//   id: "al_bashaer_foul_minya",
//   name: { en: "Al-Bashaer (Foul & Falafel)", ar: "فول وفلافل مطعم البشائر" },
//   description: { en: "Local foul & falafel place in Minya (good local rating on review directories).", ar: "مطعم فول وفلافل محلي بالمنيا (حاصل على تقييم جيد في دلائل التقييم)." },
//   imageUrl: "assets/images/al_bashaer_foul.jpg",
//   latitude: 0,
//   longitude: 0,
//   rating: 4.3,
//   reviewCount: 16,
//   cuisineType: { en: "Foul & Falafel", ar: "فول و فلافل" },
//   priceRange: { en: "Low", ar: "منخفض" },
//   openingHours: { en: "Open 05:00 AM – 01:00 AM (as listed)", ar: "مفتوح ٠٥:٠٠ ص – ٠١:٠٠ ص (مذكور)" },
//   specialties: [],
//   contactInfo: { phone: { en: "", ar: "" }, email: "" },
//   features: [],
  
// },

 {
  id: "saman_ala_asal_minya",
  name: { en: "Saman Ala Asal", ar: "سمن على عسل" },
  description: { en: "Desserts & sweets shop — active Facebook page and local delivery hotline.", ar: "محل حلويات؛ له صفحة فيسبوك نشطة وخط توصيل محلي." },
  imageUrl: "assets/images/سمن على عسل.jpg",
  latitude:28.111059519928908,
  longitude: 30.750139361021255,
  rating:4.0,
  reviewCount: 6,
  cuisineType: { en: "Desserts / Sweets", ar: "حلويات" },
  priceRange: { en: "Low to Mid", ar: "منخفض إلى متوسط" },
 openingHours: {
    en: "Wed 10:00 AM – 1:00 AM\nThu 10:00 AM – 1:00 AM\nFri 10:00 AM – 1:00 AM\nSat 10:00 AM – 1:00 AM\nSun 10:00 AM – 1:00 AM\nMon 10:00 AM – 1:00 AM\nTue 10:00 AM – 1:00 AM",
    ar: "الأربعاء ١٠:٠٠ص–١:٠٠ص\nالخميس ١٠:٠٠ص–١:٠٠ص\nالجمعة ١٠:٠٠ص–١:٠٠ص\nالسبت ١٠:٠٠ص–١:٠٠ص\nالأحد ١٠:٠٠ص–١:٠٠ص\nالاثنين ١٠:٠٠ص–١:٠٠ص\nالثلاثاء ١٠:٠٠ص–١:٠٠ص"
  },
  specialties: [
    { en: "Oriental Sweets (Konafa, Basbousa, Baklava)", ar: "حلويات شرقية (كنافة، بسبوسة، بقلاوة)" },
    { en: "Western Cakes & Pastries", ar: "تورت وحلويات غربية" },
    { en: "Ice Cream & Parfait Cups", ar: "آيس كريم وكاسات بارفيه" },
    { en: "Custom Birthday Cakes", ar: "تورت أعياد ميلاد حسب الطلب" }
  ],
  contactInfo: { phone: { en: "Hotline 16912, pages list other numbers", ar: "الخط الساخن 16912" }, email: "" },
   features: [
    { en: "Delivery", ar: "توصيل" },
    { en: "Takeaway", ar: "تيك أواي" },
    { en: "Family-friendly", ar: "مناسب للعائلات" }
  ]
}
,
{
  id: "tallah_minya",
  name: { en: "Tallah Restaurant & Café", ar: "مطعم وكافية طلة" },
  description: {
    en: "Nile-side café and restaurant in Minya on the Corniche, great view and cozy ambiance.", 
    ar: "كافية ومطعم على كورنيش المنيا، إطلالة على النيل وجو مريح."
  },
  imageUrl: "assets/images/tallah_minya.jpg",
  latitude: 28.1080581608185, 
  longitude: 30.7527176904317,
  rating:5.0
,
  reviewCount: 2,
  cuisineType: { en: "Café / Mixed", ar: "كافيه / متنوع" },
  priceRange: { en: "Mid-range", ar: "متوسط" },
  openingHours: {
    en: "Wed 10:00 AM – 12:00 AM\nThu 10:00 AM – 12:00 AM\nFri 10:00 AM – 12:00 AM\nSat 10:00 AM – 12:00 AM\nSun 10:00 AM – 12:00 AM\nMon 10:00 AM – 12:00 AM\nTue 10:00 AM – 12:00 AM",
    ar: "الأربعاء ١٠:٠٠ص–١٢:٠٠ص\nالخميس ١٠:٠٠ص–١٢:٠٠ص\nالجمعة ١٠:٠٠ص–١٢:٠٠ص\nالسبت ١٠:٠٠ص–١٢:٠٠ص\nالأحد ١٠:٠٠ص–١٢:٠٠ص\nالاثنين ١٠:٠٠ص–١٢:٠٠ص\nالثلاثاء ١٠:٠٠ص–١٢:٠٠ص"
  },
 specialties: [
    { en: "Grilled Fish & Seafood", ar: "سمك مشوي وأسماك" },
    { en: "Coffee & Breakfast / Brunch", ar: "قهوة وفطار / برانش" },
    { en: "Italian dishes (Pasta, Pizza)", ar: "أطباق إيطالية (باستا، بيتزا)" },
    { en: "Mixed grills & Shawarma", ar: "مشاوي مشكلة وشاورما" }
  ],
  contactInfo: { phone: { en: "01044844052", ar: "٠١٠٤٤٨٤٤٠٥٢" }, email: "" },
 features: [
    { en: "Nile View", ar: "إطلالة على النيل" },
    { en: "Outdoor Seating", ar: "جلسات خارجية" },
    { en: "Reservations", ar: "حجز" },
    { en: "Restroom", ar: "دورة مياه" }
  ],

}
,
{
  id: "arkan_minya",
  name: { en: "Arkan Restaurant", ar: "مطعم أركان" },
  description: {
    en: "Popular local restaurant in Minya city center serving a variety of grilled and family dishes. Busy at dinner and suitable for groups.",
    ar: "مطعم شعبي في مركز المنيا يقدم مشاوي وأطباق عائلية متنوعة. مزدحم غالباً في وقت العشاء ومناسب للجروبات."
  },
  imageUrl: "assets/images/unnamed (6).png",
  // إحداثيات تقريبية لمركز المدينة — استبدليها بالإحداثيات الدقيقة لو متوفرة
  latitude: 28.0955,
  longitude: 30.7605,
  rating: 4.3,
  reviewCount: 855,
  cuisineType: { en: "Grill / Local", ar: "مشاوي / محلي" },
  priceRange: { en: "Low to Mid", ar: "منخفض إلى متوسط" },
  openingHours: {
    en:
      "Mon 11:00 AM – 12:00 AM\nTue 11:00 AM – 12:00 AM\nWed 11:00 AM – 12:00 AM\nThu 11:00 AM – 12:00 AM\nFri 11:00 AM – 12:00 AM\nSat 11:00 AM – 12:00 AM\nSun 11:00 AM – 12:00 AM",
    ar:
      "الاثنين ١١:٠٠ص–١٢:٠٠ص\nالثلاثاء ١١:٠٠ص–١٢:٠٠ص\nالأربعاء ١١:٠٠ص–١٢:٠٠ص\nالخميس ١١:٠٠ص–١٢:٠٠ص\nالجمعة ١١:٠٠ص–١٢:٠٠ص\nالسبت ١١:٠٠ص–١٢:٠٠ص\nالأحد ١١:٠٠ص–١٢:٠٠ص"
  },
  specialties: [
    { en: "Grills", ar: "مشاوي" },
    { en: "Family platters", ar: "أطباق عائلية" },
    { en: "Traditional dishes", ar: "أكلات شعبية" }
  ],
  center: { en: "Minya Center", ar: "مركز المنيا" },
  menu: [], // املئي لاحقاً بـ MenuItem[]
  menuUrl: undefined,
  contactInfo: {
    phone: { en: "01093337343", ar: "٠١٠٩٣٣٣٧٣٤٣" },
    email: ""
  },
  features: [
    { en: "Takeaway", ar: "طلبات خارجية" },
    { en: "Indoor seating", ar: "جلسات داخلية" },
    { en: "Group-friendly", ar: "مناسب للمجموعات" }
  ],
  address: {
    en: "Minya District, Minya Center, Minya Governorate 2451204",
    ar: "قسم المنيا، مركز المنيا، محافظة المنيا 2451204"
  },
  imageGallery: [
    "assets/images/2023-01-03.png",
    "assets/images/2023-01-03 (1).png",
     "assets/images/2023-01-03 (2).png",
    "assets/images/2023-01-03 (3).png", 
    "assets/images/2023-01-03 (4).png",
    "assets/images/2023-01-03 (6).png",
     "assets/images/2023-01-03 (7).png",
    "assets/images/2023-01-03 (8).png",
     "assets/images/2023-01-03 (9).png",
    "assets/images/2023-01-03 (10).png",
     "assets/images/2023-01-03 (11).png",
      "assets/images/2023-01-03 (12).png",
       "assets/images/2023-01-03 (13).png",
       "assets/images/2023-01-03 (15).png",
          "assets/images/2023-01-03 (16).png",
           "assets/images/unnamed (7).jpg",
            "assets/images/2023-01-03 (17).png",
    "assets/images/2023-01-03 (18).png",



    "assets/images/unnamed (8).jpg",
    "assets/images/unnamed (9).jpg",
   
  ]
}
,

{
  id: "see_foul_minya",
  name: { en: "See Foul", ar: "سي فول" },
  description: {
    en: "Traditional Egyptian restaurant specializing in ful, taameya and classic breakfast & casual dishes. Located on the Corniche by the Nile — popular for early mornings and all-day casual dining.",
    ar: "مطعم مصري تقليدي متخصص في الفول والطعمية وأطباق الإفطار والأكلات الخفيفة. يقع على الكورنيش بمحاذاة النيل — مشهور للصباح والمأكولات اليومية."
  },
  imageUrl: "assets/images/unnamed (10).jpg",
  // إحداثيات تقريبية للكورنيش - استبدليها بإحداثيات دقيقة إن وُجدت
  latitude: 28.0980,
  longitude: 30.7615,
  rating: 3.9,
  reviewCount: 862,
  cuisineType: { en: "Egyptian / Breakfast", ar: "مصري / إفطار" },
  priceRange: { en: "Low", ar: "منخفض" },
  openingHours: {
    en:
      "Mon Open 24 hours\nTue Open 24 hours\nWed Open 24 hours\nThu Open 24 hours\nFri Open 24 hours\nSat Open 24 hours\nSun Open 24 hours",
    ar:
      "الاثنين نعمل على مدار 24 ساعة\nالثلاثاء نعمل على مدار 24 ساعة\nالأربعاء نعمل على مدار 24 ساعة\nالخميس نعمل على مدار 24 ساعة\nالجمعة نعمل على مدار 24 ساعة\nالسبت نعمل على مدار 24 ساعة\nالأحد نعمل على مدار 24 ساعة"
  },
  specialties: [
    { en: "Ful (fava beans)", ar: "فول" },
    { en: "Taameya (falafel)", ar: "طعمية" },
    { en: "Traditional breakfast", ar: "إفطار تقليدي" }
  ],
  center: { en: "Corniche / Minya Center", ar: "الكورنيش / مركز المنيا" },
  menu: [], // أضيفي MenuItem[] لاحقاً إذا رغبتِ
  menuUrl: undefined,
  contactInfo: {
    phone: { en: "0862324999", ar: "٠٨٦ ٢٣٢٤٩٩٩" },
    email: ""
  },
  features: [
    { en: "Takeaway", ar: "طلبات خارجية" },
    { en: "Outdoor seating", ar: "جلسات خارجية" },
    { en: "Open 24/7", ar: "مفتوح على مدار 24 ساعة" }
  ],
  address: {
    en: "4Q43+R6P, Corniche El Nil, Minya District, Minya Governorate 2451175",
    ar: "4Q43+R6P، كورنيش النيل، قسم المنيا، مركز المنيا، محافظة المنيا 2451175"
  },
  imageGallery: [
    "assets/images/unnamed (11).jpg",
  
  ]
},
{
  id: "famous_burger_minya",
  name: { en: "Famous Burger", ar: "فيماس برجر" },
  description: {
    en: "Casual burger joint known for classic burgers, fries and quick takeaway. Located on Taha Hussein Street near local landmarks.",
    ar: "مطعم برجر بسيط يشتهر بالبرجر الكلاسيكي والبطاطس وطلبات السريع. يقع في شارع طه حسين قرب معالم محلية."
  },
  imageUrl: "assets/images/unnamed (13).jpg",
  // إحداثيات تقريبية — أرسلي إحداثيات خرائط أو رابط للتثبيت الدقيق
  latitude: 28.0975,
  longitude: 30.7608,
  rating: 4.4,
  reviewCount: 165,
  cuisineType: { en: "Burgers / Fast Food", ar: "برجر / وجبات سريعة" },
  priceRange: { en: "Low to Mid", ar: "منخفض إلى متوسط" },
  openingHours: {
    en: "", // لم تُزود ساعات العمل — اتركيه فارغاً أو ضعي أحد الاقتراحات
    ar: ""
  },
  specialties: [
    { en: "Burgers", ar: "برجر" },
    { en: "Fries & Sides", ar: "بطاطس ومقبلات" },
    { en: "Takeaway", ar: "طلبات خارجية" }
  ],
  center: { en: "Taha Hussein, Minya", ar: "طه حسين، أول المنيا" },
  menu: [], // املئي لاحقاً بـ MenuItem[] إذا حابة
  menuUrl: undefined,
  contactInfo: {
    phone: { en: "", ar: "" },
    email: ""
  },
  features: [
    { en: "Takeaway", ar: "طلبات خارجية" },
    { en: "Fast service", ar: "خدمة سريعة" },
    { en: "Delivery (if available)", ar: "توصيل (إن وُجد)" }
  ],
  address: {
    en: "Next to Dr. Mohamed Farghaly Pharmacy, Taha Hussein St., Minya (in front of Bandokka Grills), 61111",
    ar: "بجوار صيدلية د. محمد فرغلي، شارع طه حسين، المنيا (أمام مشويات بندقة)، 61111"
  },
  imageGallery: [
    "assets/images/unnamed (12).jpg",
     "assets/images/202678602_125463026379368_955375323180507063_n.png"
  ]
},
{
  id: "mcdonalds_minya",
  name: { en: "McDonald's Minya", ar: "ماكدونالدز المنيا" },
  description: {
    en: "International fast-food chain serving burgers, fries, coffee, and breakfast. Located at Nefertiti Hotel, Minya Corniche.",
    ar: "سلسلة الوجبات السريعة العالمية تقدم البرجر والبطاطس والقهوة والإفطار. تقع داخل فندق نفرتيتي بكورنيش المنيا."
  },
  imageUrl: "assets/images/unnamed (14).jpg",
  // الإحداثيات تقريبية قرب فندق نفرتيتي على كورنيش المنيا
  latitude: 28.0959,
  longitude: 30.7598,
  rating: 4.2,
  reviewCount: 1315,
  cuisineType: { en: "Fast Food / Burgers", ar: "وجبات سريعة / برجر" },
  priceRange: { en: "Mid", ar: "متوسط" },
  openingHours: {
    en:
      "Mon 07:00 AM – 03:00 AM\nTue 07:00 AM – 03:00 AM\nWed 07:00 AM – 03:00 AM\nThu 07:00 AM – 03:00 AM\nFri 07:00 AM – 03:00 AM\nSat 07:00 AM – 03:00 AM\nSun 07:00 AM – 03:00 AM",
    ar:
      "الاثنين ٧:٠٠ص–٣:٠٠ص\nالثلاثاء ٧:٠٠ص–٣:٠٠ص\nالأربعاء ٧:٠٠ص–٣:٠٠ص\nالخميس ٧:٠٠ص–٣:٠٠ص\nالجمعة ٧:٠٠ص–٣:٠٠ص\nالسبت ٧:٠٠ص–٣:٠٠ص\nالأحد ٧:٠٠ص–٣:٠٠ص"
  },
  specialties: [
    { en: "Burgers", ar: "برجر" },
    { en: "Fries", ar: "بطاطس" },
    { en: "Breakfast Menu", ar: "قائمة الإفطار" },
    { en: "Coffee & Desserts", ar: "قهوة وحلويات" }
  ],
  center: { en: "Corniche / Nefertiti Hotel", ar: "كورنيش المنيا / فندق نفرتيتي" },
  menu: [], // أضيفي عناصر القائمة إذا حابة لاحقاً
  menuUrl: undefined,
  contactInfo: {
    phone: { en: "0221600377", ar: "٠٢ ٢١٦٠٠٣٧٧" },
    email: ""
  },
  features: [
    { en: "Delivery", ar: "توصيل" },
    { en: "Drive-thru", ar: "طلب من السيارة" },
    { en: "Family seating", ar: "جلسات عائلية" },
    { en: "Breakfast available", ar: "إفطار متاح" }
  ],
  address: {
    en: "Nefertiti Hotel, Minya Corniche, Minya District, Minya Governorate 2451176",
    ar: "فندق نفرتيتي، كورنيش المنيا، قسم المنيا، أول المنيا، محافظة المنيا 2451176"
  },
  imageGallery: [
    "assets/images/mcdonalds-minya_1.jpg",
    "assets/images/mcdonalds-minya_2.jpg"
  ]
},



{
  id: "pizza_suwaisy_minya",
  name: { en: "Pizza & Pastries El-Suwaisy", ar: "بيتزا وفطائر السويسي" },
  description: {
    en: "Local pizzeria and pastry shop in Minya serving pizzas, savory pies and baked pastries — popular for takeaways and family meals.",
    ar: "محل بيتزا وفطائر محلي في المنيا يقدم بيتزا، فطائر مملحة ومعجنات مخبوزة — مشهور للسفري والوجبات العائلية."
  },
  imageUrl: "assets/images/unnamed (50).jpg",
  // إحداثيات مُقدّرة لمركز المنيا — أستطيع تحديثها بدقّة لو عندك رابط Google Maps
  latitude: 28.095000,
  longitude: 30.760000,
  rating: 3.7,
  reviewCount: 185,
  cuisineType: { en: "Pizza & Pastries", ar: "بيتزا وفطائر" },
  priceRange: { en: "Affordable", ar: "اقتصادي" },
  openingHours: {
    en: "Wed 10:00 AM – 12:00 AM\nThu 10:00 AM – 12:00 AM\nFri 10:00 AM – 2:00 AM\nSat 10:00 AM – 12:00 AM\nSun 10:00 AM – 12:00 AM\nMon 10:00 AM – 12:00 AM\nTue 10:00 AM – 12:00 AM",
    ar: "الأربعاء ١٠:٠٠ص–١٢:٠٠ص\nالخميس ١٠:٠٠ص–١٢:٠٠ص\nالجمعة ١٠:٠٠ص–٢:٠٠ص\nالسبت ١٠:٠٠ص–١٢:٠٠ص\nالأحد ١٠:٠٠ص–١٢:٠٠ص\nالاثنين ١٠:٠٠ص–١٢:٠٠ص\nالثلاثاء ١٠:٠٠ص–١٢:٠٠ص"
  },
  imageGallery: [
    "assets/images/unnamed (51).jpg",
    "assets/images/unnamed (52).jpg",
     "assets/images/unnamed (53).jpg",
      "assets/images/unnamed (54).jpg",
       "assets/images/unnamed (55).jpg",
        "assets/images/unnamed (56).jpg"
  ],
  specialties: [
    { en: "Wood-fired Pizza", ar: "بيتزا" },
    { en: "Savory Pies", ar: "فطائر مملحة" },
    { en: "Sweet & Savory Pastries", ar: "معجنات حلوة ومالحة" },
    { en: "Takeaway Orders", ar: "سفري" }
  ],
  contactInfo: {
    phone: { en: "0862368442", ar: "٠٨٦٢٣٦٨٤٤٢" },
    email: ""
  },
  features: [
    { en: "Dine-in & takeaway", ar: "تناول داخل المطعم وسفري" },
    { en: "Family seating", ar: "جلسات عائلية" },
    { en: "Late hours on Fridays", ar: "ساعات متأخرة يوم الجمعة" },
    { en: "Cash payment", ar: "الدفع نقدي" }
  ],
  address: {
    en: "3QX4+5XR, Minya District, Minya Center, Minya Governorate 2451153",
    ar: "3QX4+5XR، قسم المنيا، مركز المنيا، محافظة المنيا 2451153"
  }
},
{
  id: "doctorbox_minya",
  name: { en: "DOCTOR BOX Fried Chicken & Burger", ar: "دكتور بوكس - فرايد تشيكن وبرجر" },
  description: {
    en: "Popular fast-food spot in Minya specializing in fried chicken and burgers, with late-night hours and takeaway options.",
    ar: "مطعم فاست فود شهير بالمنيا متخصص في الفرايد تشيكن والبرجر، يعمل لساعات متأخرة ويوفر خدمة السفري."
  },
  imageUrl: "assets/images/unnamed (57).jpg",
  // إحداثيات مُقدّرة (عدّلي لو عندك رابط Google Maps)
  latitude: 28.098500,
  longitude: 30.756500,
  rating: 4.7,
  reviewCount: 513,
  cuisineType: { en: "Fried Chicken & Burgers", ar: "فرايد تشيكن وبرجر" },
  priceRange: { en: "200–400 E£ per person", ar: "٢٠٠–٤٠٠ جنيه للفرد" },
  openingHours: {
    en: "Sun 12:00 PM – 3:00 AM\nMon 12:00 PM – 3:00 AM\nTue 12:00 PM – 3:00 AM\nWed 12:00 PM – 3:00 AM\nThu 12:00 PM – 3:00 AM\nFri 12:00 PM – 3:00 AM\nSat 12:00 PM – 3:00 AM",
    ar: "الأحد ١٢:٠٠م–٣:٠٠ص\nالاثنين ١٢:٠٠م–٣:٠٠ص\nالثلاثاء ١٢:٠٠م–٣:٠٠ص\nالأربعاء ١٢:٠٠م–٣:٠٠ص\nالخميس ١٢:٠٠م–٣:٠٠ص\nالجمعة ١٢:٠٠م–٣:٠٠ص\nالسبت ١٢:٠٠م–٣:٠٠ص"
  },
  imageGallery: [
    // "assets/images/doctorbox_1.jpg",
    // "assets/images/doctorbox_2.jpg"
  ],
  specialties: [
    { en: "Fried Chicken Buckets", ar: "دلاء فرايد تشيكن" },
    { en: "Signature Burgers", ar: "برجر مميز" },
    { en: "Fries & Sides", ar: "بطاطس ومقبلات" },
    { en: "Takeaway & Delivery", ar: "سفري وتوصيل" }
  ],
  contactInfo: {
    phone: { en: "01501010158", ar: "٠١٥٠١٠١٠١٥٨" },
    email: ""
  },
  features: [
    { en: "Late-night service", ar: "خدمة لساعات متأخرة" },
    { en: "Takeaway & delivery", ar: "سفري وتوصيل" },
    { en: "Cash & card payment", ar: "الدفع نقدي وبطاقة" }
  ],
  address: {
    en: "4P7X+H6H, Minya District, Old Minya, Minya Governorate 2451145",
    ar: "4P7X+H6H، قسم المنيا، أول المنيا، محافظة المنيا 2451145"
  }
},
{
  id: "cesar_cafe_minya",
  name: { en: "Cesar Cafe", ar: "سيزار كافية" },
  description: {
    en: "Riverside cafe on Minya Corniche offering coffee, light meals and pastries — popular for relaxed gatherings and views of the Nile.",
    ar: "كافية على كورنيش النيل بالمنيا تقدم القهوة، وجبات خفيفة ومعجنات — منتشرة للاجتماعات الهادئة والاستمتاع بمنظر النيل."
  },
  imageUrl: "assets/images/2024-06-26.png",
  // إحداثيات مُقدّرة لموقع كورنيش النيل بالمنيا — أستطيع تعديلها بدقة لو تبعتي لينك Google Maps
  latitude: 28.095500,
  longitude: 30.759000,
  rating: 3.9,
  reviewCount: 713,
  cuisineType: { en: "Cafe", ar: "كافية" },
  priceRange: { en: "Mid-range", ar: "متوسط" },
  openingHours: {
    en: "Wed 9:00 AM – 1:00 AM\nThu 9:00 AM – 1:00 AM\nFri 9:00 AM – 1:00 AM\nSat 9:00 AM – 1:00 AM\nSun 9:00 AM – 1:00 AM\nMon 9:00 AM – 1:00 AM\nTue 9:00 AM – 1:00 AM",
    ar: "الأربعاء ٩:٠٠ص–١:٠٠ص\nالخميس ٩:٠٠ص–١:٠٠ص\nالجمعة ٩:٠٠ص–١:٠٠ص\nالسبت ٩:٠٠ص–١:٠٠ص\nالأحد ٩:٠٠ص–١:٠٠ص\nالاثنين ٩:٠٠ص–١:٠٠ص\nالثلاثاء ٩:٠٠ص–١:٠٠ص"
  },
  imageGallery: [
    "assets/images/cesar_cafe_1.jpg",
    "assets/images/cesar_cafe_2.jpg"
  ],
  specialties: [
    { en: "Specialty Coffee", ar: "قهوة مميزة" },
    { en: "Pastries & Desserts", ar: "معجنات وحلويات" },
    { en: "Breakfast & Brunch", ar: "فطار وبرانش" },
    { en: "Light Meals", ar: "وجبات خفيفة" }
  ],
  contactInfo: {
    phone: { en: "01202191191", ar: "٠١٢٠٢١٩١١٩١" },
    email: ""
  },
  features: [
    { en: "Riverside seating", ar: "جلسات على النيل" },
    { en: "Wi-Fi", ar: "واي فاي" },
    { en: "Dine-in & takeaway", ar: "تناول داخل الكافية وسفري" }
  ],
  address: {
    en: "Corniche El Nil, Minya District, Minya Center, Minya Governorate 2451173",
    ar: "كورنيش النيل، قسم المنيا، مركز المنيا، محافظة المنيا 2451173"
  }
},



{
  id: "brego_minya",
  name: { en: "Brego", ar: "بريجو" },
  description: {
    en: "24-hour restaurant in Minya offering a variety of casual dining dishes and quick bites.",
    ar: "مطعم يعمل على مدار الساعة في المنيا يقدم أطباق كاجوال وسندوتشات ووجبات سريعة."
  },
  imageUrl: "assets/images/unnamed (29).jpg",
  // إحداثيات مُقدّرة لمركز المنيا — أستطيع تعديلها بدقة لو عندك رابط جوجل مابس
  latitude: 28.098000,
  longitude: 30.757000,
  rating: 4.1,
  reviewCount: 535,
  cuisineType: { en: "Casual Dining", ar: "مطاعم كاجوال" },
  priceRange: { en: "Mid-range", ar: "متوسط" },
  openingHours: {
    en: "Sun Open 24 hours\nMon Open 24 hours\nTue Open 24 hours\nWed Open 24 hours\nThu Open 24 hours\nFri Open 24 hours\nSat Open 24 hours",
    ar: "الأحد نعمل على مدار 24 ساعة\nالاثنين نعمل على مدار 24 ساعة\nالثلاثاء نعمل على مدار 24 ساعة\nالأربعاء نعمل على مدار 24 ساعة\nالخميس نعمل على مدار 24 ساعة\nالجمعة نعمل على مدار 24 ساعة\nالسبت نعمل على مدار 24 ساعة"
  },
  imageGallery: [
    "assets/images/unnamed (30).jpg",
    "assets/images/unnamed (31).jpg",
      "assets/images/unnamed (33).jpg",
        "assets/images/unnamed (34).jpg",
          "assets/images/unnamed (35).jpg",
            "assets/images/unnamed (36).jpg",
            "assets/images/unnamed (41).jpg",
            "assets/images/unnamed (40).jpg",
            "assets/images/unnamed (39).jpg",
            "assets/images/unnamed (38).jpg",

  ],
  specialties: [
    { en: "Sandwiches & Fast Meals", ar: "سندوتشات ووجبات سريعة" },
    { en: "Grills", ar: "مشويات" },
    { en: "Coffee & Desserts", ar: "قهوة وحلويات" }
  ],
  contactInfo: {
    phone: { en: "", ar: "" },
    email: ""
  },
  features: [
    { en: "Open 24 hours", ar: "يعمل على مدار الساعة" },
    { en: "Dine-in & takeaway", ar: "تناول داخل المطعم وسفري" }
  ],
  address: {
    en: "4Q53+36V, Minya District, Old Minya, Minya Governorate 2451175",
    ar: "4Q53+36V، قسم المنيا، أول المنيا، محافظة المنيا 2451175"
  }
}
,
{
  id: "carbiano_minya",
  name: { en: "Carbiano", ar: "كربيانو" },
  description: {
    en: "Casual dining restaurant in Minya offering a variety of fast food and grilled dishes with comfortable seating.",
    ar: "مطعم كاجوال في المنيا يقدم وجبات سريعة ومشويات متنوعة مع جلسات مريحة."
  },
  imageUrl: "assets/images/unnamed (19).jpg",
  latitude: 28.109920,
  longitude: 30.750450,
  rating: 3.7,
  reviewCount: 475,
  cuisineType: { en: "Fast Food & Grills", ar: "وجبات سريعة ومشويات" },
  priceRange: { en: "Mid-range", ar: "متوسط" },
  openingHours: {
    en: "Sun 11:00 AM – 1:00 AM\nMon 11:00 AM – 1:00 AM\nTue 11:00 AM – 1:00 AM\nWed 11:00 AM – 1:00 AM\nThu 11:00 AM – 1:00 AM\nFri 11:00 AM – 1:00 AM\nSat 11:00 AM – 1:00 AM",
    ar: "الأحد ١١:٠٠ص–١:٠٠ص\nالاثنين ١١:٠٠ص–١:٠٠ص\nالثلاثاء ١١:٠٠ص–١:٠٠ص\nالأربعاء ١١:٠٠ص–١:٠٠ص\nالخميس ١١:٠٠ص–١:٠٠ص\nالجمعة ١١:٠٠ص–١:٠٠ص\nالسبت ١١:٠٠ص–١:٠٠ص"
  },
  imageGallery: [
    "assets/images/2024-12-17.png",
    "assets/images/unnamed (20).jpg",
      "assets/images/unnamed (21).jpg",
        "assets/images/unnamed (22).jpg",
          "assets/images/2024-12-17 (1).png",
            "assets/images/unnamed (23).jpg",
              "assets/images/unnamed (24).jpg",
                "assets/images/unnamed (25).jpg",
                  "assets/images/unnamed (26).jpg",
                    "assets/images/unnamed (27).jpg",
                      "assets/images/unnamed (28).jpg"
  ],
  specialties: [
    { en: "Burgers", ar: "برجر" },
    { en: "Grilled Chicken", ar: "دجاج مشوي" },
    { en: "Pasta Dishes", ar: "مكرونات" },
    { en: "Sandwiches", ar: "سندوتشات" }
  ],
  contactInfo: {
    phone: { en: "01064116662", ar: "٠١٠٦٤١١٦٦٦٢" },
    email: ""
  },
  features: [
    { en: "Family seating", ar: "جلسات عائلية" },
    { en: "Dine-in & takeaway", ar: "تناول داخل المطعم وسفري" },
    { en: "Cash payment", ar: "الدفع نقدي" }
  ]
}

,
{
  id: "mr_chix_minya",
  name: { en: "Mr. Chix", ar: "مستر شيكس" },
  description: {
    en: "Popular fried chicken and sandwich restaurant on Taha Hussein Street, offering crispy chicken meals, sandwiches, and fast service.",
    ar: "مطعم دجاج مقلي وسندوتشات شهير في شارع طه حسين، يقدم وجبات دجاج مقرمشة وسندوتشات وخدمة سريعة."
  },
  imageUrl: "assets/images/unnamed (15).jpg",
  // إحداثيات تقريبية لشارع طه حسين بالمنيا
  latitude: 28.0972,
  longitude: 30.7609,
  rating: 4.2,
  reviewCount: 154,
  cuisineType: { en: "Fried Chicken / Fast Food", ar: "دجاج مقلي / وجبات سريعة" },
  priceRange: { en: "Low to Mid", ar: "منخفض إلى متوسط" },
  openingHours: {
    en:
      "Mon 12:00 PM – 02:00 AM\nTue 12:00 PM – 02:00 AM\nWed 12:00 PM – 02:00 AM\nThu 12:00 PM – 02:00 AM\nFri 12:00 PM – 02:00 AM\nSat 12:00 PM – 02:00 AM\nSun 12:00 PM – 02:00 AM",
    ar:
      "الاثنين ١٢:٠٠م–٢:٠٠ص\nالثلاثاء ١٢:٠٠م–٢:٠٠ص\nالأربعاء ١٢:٠٠م–٢:٠٠ص\nالخميس ١٢:٠٠م–٢:٠٠ص\nالجمعة ١٢:٠٠م–٢:٠٠ص\nالسبت ١٢:٠٠م–٢:٠٠ص\nالأحد ١٢:٠٠م–٢:٠٠ص"
  },
  specialties: [
    { en: "Fried Chicken", ar: "دجاج مقلي" },
    { en: "Chicken Sandwiches", ar: "ساندوتشات دجاج" },
    { en: "Family Meals", ar: "وجبات عائلية" }
  ],
  center: { en: "Taha Hussein, Minya", ar: "طه حسين، مركز المنيا" },
  menu: [], // أضيفي عناصر المينيو لاحقاً
  menuUrl: undefined,
  contactInfo: {
    phone: { en: "01029292199", ar: "٠١٠٢٩٢٩٢١٩٩" },
    email: ""
  },
  features: [
    { en: "Delivery", ar: "توصيل" },
    { en: "Takeaway", ar: "طلبات خارجية" },
    { en: "Indoor seating", ar: "جلسات داخلية" }
  ],
  address: {
    en: "Taha Hussein Street, Minya District, Minya Governorate 2451140",
    ar: "طه حسين، قسم المنيا، مركز المنيا، محافظة المنيا 2451140"
  },
  imageGallery: [
    "assets/images/unnamed (16).jpg",
    "assets/images/unnamed (18).jpg"
  ]
}












  // === نهاية قائمة مطاعم مركز المنيا (نسخة مبدئية) ===
];

// Ensure each RAW entry has an explicit `menuUrl` field (useful when inspecting the raw array directly)
for (const r of RAW_RESTAURANTS) {
  if (!r.menuUrl && !r.menu) {
    r.menuUrl = `/assets/menus/${r.id}.pdf`;
  } else if (!r.menuUrl && r.menu) {
    r.menuUrl = r.menu; // canonicalize menu -> menuUrl
  }
}

// Ensure exported `restaurants` conforms to Restaurant model and includes a `menuUrl` for each entry.
export const restaurants: Restaurant[] = RAW_RESTAURANTS.map((r: any) => ({
  ...r,
  // Ensure every exported restaurant has an imageGallery (use the provided fallback image when missing)
  imageGallery: r?.imageGallery ?? ["/assets/images/470498594_933892548838992_4009911687513985324_n (1).jpg"],
  // menuUrl is guaranteed by the loop above; keep compatibility for cases where explicit values exist
  menuUrl: r?.menuUrl ?? r?.menu ?? `/assets/menus/${r?.id}.pdf`,
} as Restaurant));