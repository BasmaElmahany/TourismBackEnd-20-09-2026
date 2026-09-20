const https = require('https');

const RAW_RESTAURANTS = [
  {
    id: "minya_1",
    name: { en: "Orked Restaurant", ar: "مطعم أوركيد" },
    description: {
      en: "Traditional Egyptian cuisine by the Nile with scenic views",
      ar: "مأكولات مصرية تقليدية مطلة على النيل"
    },
    imageUrl: "assets/images/unnamed (3).png",
    imageGallery: ["assets/images/490768648_1076963261132257_5356947501708733683_n.jpg"],
    menuUrl: "/assets/menus/minya_1.pdf",
    latitude: 28.1099,
    longitude: 30.7503,
    rating: 4.3,
    reviewCount: 2635,
    cuisineType: { en: "Egyptian", ar: "مصري" },
    priceRange: { en: "Mid-range", ar: "متوسط" },
    openingHours: {
      en: "Wed-Tue 12:00 PM – 2:00 AM",
      ar: "طوال أيام الأسبوع ١٢:٠٠م–٢:٠٠ص"
    },
    specialties: [],
    center: { en: "Minya", ar: "المنيا" },
    contactInfo: {
      phone: { en: "086 2356999", ar: "٠٨٦ ٢٣٥٦٩٩٩" },
      email: ""
    },
    features: [
      { en: "Nile View", ar: "إطلالة على النيل" }
    ]
  },
  {
    id: "minya_2",
    name: { en: "Bayada Seafood", ar: "مطعم البياضة" },
    description: {
      en: "Seafood and classic Egyptian dishes",
      ar: "أطباق سمك وأكلات مصرية كلاسيكية"
    },
    imageUrl: "assets/images/Minya-seafood-.jpg",
    imageGallery: ["assets/images/menus/bayada_menu.jpg"],
    menuUrl: "/assets/menus/minya_2.pdf",
    latitude: 28.099254,
    longitude: 30.756527,
    rating: 3.9,
    reviewCount: 142,
    cuisineType: { en: "Seafood, Egyptian", ar: "أسماك، مصري" },
    priceRange: { en: "Mid-range", ar: "متوسط" },
    openingHours: {
      en: "Wed-Tue 8:00 AM – 2:00 AM",
      ar: "طوال أيام الأسبوع ٨:٠٠ص–٢:٠٠ص"
    },
    specialties: [],
    center: { en: "Minya", ar: "المنيا" },
    contactInfo: {
      phone: { en: "086 2369550", ar: "٠٨٦ ٢٣٦٩٥٥٠" },
      email: ""
    },
    features: [
      { en: "Restroom", ar: "مرحاض" }
    ]
  },
  {
    id: "mallawi_1",
    name: { en: "Chicky Door", ar: "تشيكي دور" },
    description: {
      en: "Fast food / take-away in Mallawi",
      ar: "وجبات سريعة / تيك أواي في ملوي"
    },
    imageUrl: "assets/images/Chicky Door.jpg",
    imageGallery: ["/assets/images/470498594_933892548838992_4009911687513985324_n (1).jpg"],
    menuUrl: "/assets/menus/mallawi_1.pdf",
    latitude: 27.73813,
    longitude: 30.847042,
    rating: 3.9,
    reviewCount: 81,
    cuisineType: { en: "Fast Food", ar: "وجبات سريعة" },
    priceRange: { en: "Low to Mid", ar: "منخفض إلى متوسط" },
    openingHours: { en: "10:00 AM – 12:00 AM", ar: "١٠:٠٠ ص – ١٢:٠٠ ص" },
    specialties: [],
    center: { en: "Mallawi", ar: "ملوي" },
    contactInfo: {
      phone: { en: "01050315333", ar: "٠١٠٥٠٣١٥٣٣٣" },
      email: ""
    },
    features: []
  },
  {
    id: "mallawi_2",
    name: { en: "Beit ElEzz (Beit El Ezz Mallawi)", ar: "مطعم بيت العز" },
    description: {
      en: "Family style restaurant specializing in grills, mandi, pizza",
      ar: "مطعم عائلي متخصص في المشاوي، المندي، البيتزا والطواجن"
    },
    imageUrl: "assets/images/Beit ElEzz (Beit El Ezz Mallawi).jpg",
    imageGallery: ["/assets/images/470498594_933892548838992_4009911687513985324_n (1).jpg"],
    menuUrl: "/assets/menus/mallawi_2.pdf",
    latitude: 27.738564,
    longitude: 30.844415,
    rating: 4.3,
    reviewCount: 276,
    cuisineType: { en: "Grill, Mandi, Pizza", ar: "مشاوي، مندي، بيتزا" },
    priceRange: { en: "Mid-range", ar: "متوسط" },
    openingHours: { en: "Open 24 hours", ar: "يعمل على مدار 24 ساعة" },
    specialties: [],
    center: { en: "Mallawi", ar: "ملوي" },
    contactInfo: {
      phone: { en: "01110341113", ar: "٠١١١٠٣٤١١١٣" },
      email: ""
    },
    features: []
  },
  {
    id: "mallawi_4",
    name: { en: "Ayman Restaurant", ar: "مطعم أيمن" },
    description: {
      en: "Local eatery in Mallawi (delivery available)",
      ar: "مطعم محلي في ملوي (توصيل متاح)"
    },
    imageUrl: "assets/images/Ayman Restaurant (مطعم أيمن).jpg",
    imageGallery: ["/assets/images/470498594_933892548838992_4009911687513985324_n (1).jpg"],
    menuUrl: "/assets/menus/mallawi_4.pdf",
    latitude: 27.738154,
    longitude: 30.844709,
    rating: 4.2,
    reviewCount: 27,
    cuisineType: { en: "Egyptian", ar: "مصري" },
    priceRange: { en: "Low to Mid", ar: "منخفض إلى متوسط" },
    openingHours: { en: "3:00 PM – 3:00 AM", ar: "٣:٠٠ م – ٣:٠٠ ص" },
    specialties: [],
    center: { en: "Mallawi", ar: "ملوي" },
    contactInfo: {
      phone: { en: "01090751710", ar: "٠١٠٩٠٧٥١٧١٠" },
      email: ""
    },
    features: []
  },
  {
    id: "beni_1",
    name: { en: "Piano Cafe", ar: "بيانو كافيه" },
    description: {
      en: "Cafe & light meals — popular in Beni Mazar",
      ar: "كافيه ووجبات خفيفة — مشهور في بني مزار"
    },
    imageUrl: "assets/images/Piano Cafe.jpg",
    imageGallery: ["/assets/images/470498594_933892548838992_4009911687513985324_n (1).jpg"],
    menuUrl: "/assets/menus/beni_1.pdf",
    latitude: 28.495016,
    longitude: 30.80757,
    rating: 3.8,
    reviewCount: 137,
    cuisineType: { en: "Cafe", ar: "كافيه" },
    priceRange: { en: "Low to Mid", ar: "منخفض إلى متوسط" },
    openingHours: { en: "8:30 AM – 2:00 AM", ar: "٨:٣٠ ص – ٢:٠٠ ص" },
    specialties: [
      { en: "Coffee", ar: "قهوة" },
      { en: "Sandwiches", ar: "ساندوتشات" }
    ],
    center: { en: "Beni Mazar", ar: "بني مزار" },
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
    name: { en: "El Omda (Al Omda)", ar: "مطعم العمدة" },
    description: {
      en: "Local grill & family restaurant in Beni Mazar",
      ar: "مطعم مشاوي وعائلي في بني مزار"
    },
    imageUrl: "assets/images/El Omda (Al Omda).png",
    imageGallery: ["/assets/images/470498594_933892548838992_4009911687513985324_n (1).jpg"],
    menuUrl: "/assets/menus/beni_2.pdf",
    latitude: 28.498687,
    longitude: 30.804526,
    rating: 3.7,
    reviewCount: 101,
    cuisineType: { en: "Egyptian / Grill", ar: "مصري / مشاوي" },
    priceRange: { en: "Low to Mid", ar: "منخفض إلى متوسط" },
    openingHours: { en: "10:00 AM - 11:00 PM", ar: "١٠:٠٠ ص - ١١:٠٠ م" },
    specialties: [
      { en: "Grills", ar: "مشاوي" },
      { en: "Masry Dishes", ar: "أكلات مصرية" }
    ],
    center: { en: "Beni Mazar", ar: "بني مزار" },
    contactInfo: {
      phone: { en: "01092937948", ar: "٠١٠٩٢٩٣٧٩٤٨" },
      email: ""
    },
    features: []
  },
  {
    id: "beni_3",
    name: { en: "Tito's Restaurant", ar: "مطعم تيتو" },
    description: {
      en: "Casual local restaurant listed on TripAdvisor",
      ar: "مطعم محلي مدرج في TripAdvisor"
    },
    imageUrl: "assets/images/Tito's Restaurant - Beni Mazar.jpg",
    imageGallery: ["/assets/images/470498594_933892548838992_4009911687513985324_n (1).jpg"],
    menuUrl: "/assets/menus/beni_3.pdf",
    latitude: 28.495963,
    longitude: 30.81336,
    rating: 3.1,
    reviewCount: 35,
    cuisineType: { en: "Egyptian", ar: "مصري" },
    priceRange: { en: "Low to Mid", ar: "منخفض إلى متوسط" },
    openingHours: { en: "10:00 AM – 12:00 AM", ar: "١٠:٠٠ ص – ١٢:٠٠ ص" },
    specialties: [],
    center: { en: "Beni Mazar", ar: "بني مزار" },
    contactInfo: {
      phone: { en: "0867838400", ar: "٠٨٦٧٨٣٨٤٠٠" },
      email: ""
    },
    features: []
  },
  {
    id: "deir_1",
    name: { en: "Abo Ali Fried Chicken", ar: "أبو علي - دير مواس" },
    description: {
      en: "Fried chicken / fast food chain",
      ar: "وجبات دجاج مقلية / وجبات سريعة"
    },
    imageUrl: "assets/images/Abo Ali Fried Chicken.jpg",
    imageGallery: ["/assets/images/470498594_933892548838992_4009911687513985324_n (1).jpg"],
    menuUrl: "/assets/menus/deir_1.pdf",
    latitude: 27.644352,
    longitude: 30.858226,
    rating: 3.9,
    reviewCount: 23,
    cuisineType: { en: "Fast Food", ar: "وجبات سريعة" },
    priceRange: { en: "Low", ar: "منخفض" },
    openingHours: { en: "Open 24 hours", ar: "يعمل على مدار 24 ساعة" },
    specialties: [
      { en: "Fried Chicken", ar: "دجاج مقلي" }
    ],
    center: { en: "Deir Mawas", ar: "دير مواس" },
    contactInfo: {
      phone: { en: "01001436173", ar: "٠١٠٠١٤٣٦١٧٣" },
      email: ""
    },
    features: [
      { en: "Delivery", ar: "توصيل" }
    ]
  },
  {
    id: "abuq_2",
    name: { en: "Fritto Burger", ar: "فريتو برجر" },
    description: {
      en: "Popular local burger chain/fast food in Abu Qurqas",
      ar: "سلسلة برجر محلية ووجبات سريعة في أبو قرقاص"
    },
    imageUrl: "assets/images/Fritto Burger - Abu Qurqas.jpg",
    imageGallery: ["/assets/images/470498594_933892548838992_4009911687513985324_n (1).jpg"],
    menuUrl: "/assets/menus/abuq_2.pdf",
    latitude: 27.935556,
    longitude: 30.858226,
    rating: 4.6,
    reviewCount: 10,
    cuisineType: { en: "Fast Food", ar: "وجبات سريعة" },
    priceRange: { en: "Low", ar: "منخفض" },
    openingHours: { en: "2:00 PM – 2:00 AM", ar: "٢:٠٠ م – ٢:٠٠ ص" },
    specialties: [
      { en: "Burgers", ar: "برجر" }
    ],
    center: { en: "Abu Qurqas", ar: "أبو قرقاص" },
    contactInfo: {
      phone: { en: "01148263649", ar: "٠١١٤٨٢٦٣٦٤٩" },
      email: ""
    },
    features: [
      { en: "Delivery", ar: "توصيل" }
    ]
  },
  {
    id: "abuq_3",
    name: { en: "Chef Mayer & Mood's", ar: "شيف ماير ومودز" },
    description: {
      en: "Restaurant & drinks — local Abu Qurqas venue",
      ar: "مطعم ومشروبات — مكان محلي في أبو قرقاص"
    },
    imageUrl: "assets/images/Chef Mayer & Mood's (Abu Qurqas).jpg",
    imageGallery: ["/assets/images/470498594_933892548838992_4009911687513985324_n (1).jpg"],
    menuUrl: "/assets/menus/abuq_3.pdf",
    latitude: 27.936116,
    longitude: 30.858226,
    rating: 4.3,
    reviewCount: 41,
    cuisineType: { en: "Mixed", ar: "متنوع" },
    priceRange: { en: "Mid-range", ar: "متوسط" },
    openingHours: { en: "1:00 PM – 2:00 AM", ar: "١:٠٠ م – ٢:٠٠ ص" },
    specialties: [],
    center: { en: "Abu Qurqas", ar: "أبو قرقاص" },
    contactInfo: {
      phone: { en: "01282420500", ar: "٠١٢٨٢٤٢٠٥٠٠" },
      email: ""
    },
    features: []
  },
  {
    id: "sam_1",
    name: { en: "Beit ElSham", ar: "بيت الشام - سمالوط" },
    description: {
      en: "Syrian-style restaurant and shawarma, popular in Samalut",
      ar: "مطعم سوري وشاورما، مشهور في سمالوط"
    },
    imageUrl: "assets/images/Beit ElSham.jpg",
    imageGallery: ["/assets/images/470498594_933892548838992_4009911687513985324_n (1).jpg"],
    menuUrl: "/assets/menus/sam_1.pdf",
    latitude: 28.312556,
    longitude: 30.709104,
    rating: 3.8,
    reviewCount: 207,
    cuisineType: { en: "Syrian / Middle Eastern", ar: "سوري / شرق أوسطي" },
    priceRange: { en: "Low to Mid", ar: "منخفض إلى متوسط" },
    openingHours: { en: "1:00 PM – 3:00 AM", ar: "١:٠٠ م – ٣:٠٠ ص" },
    specialties: [
      { en: "Shawarma", ar: "شاورما" }
    ],
    center: { en: "Samalut", ar: "سمالوط" },
    contactInfo: {
      phone: { en: "01026879698", ar: "٠١٠٢٦٨٧٩٦٩٨" },
      email: ""
    },
    features: [
      { en: "Takeaway", ar: "تيك أواي" },
      { en: "Delivery", ar: "توصيل" }
    ]
  },
  {
    id: "freika_minya",
    name: { en: "Freekeh Restaurant Minya", ar: "مطعم فريكة المنيا" },
    description: {
      en: "Syrian-style fast food & shawarma; branch on Taha Hussein near Sports Club.",
      ar: "مطبخ سوري وشاورما؛ فرع في شارع طه حسين قرب سور النادي."
    },
    imageUrl: "assets/images/مطعم فريكة.jpg",
    imageGallery: [
      "/assets/images/freekeh-restaurant_menu_1.jpg",
      "/assets/images/freekeh-restaurant_menu_2.jpg",
      "/assets/images/freekeh-restaurant_menu_3.jpg",
      "/assets/images/freekeh-restaurant_menu_4.jpg"
    ],
    menuUrl: "/assets/menus/freika_minya.pdf",
    latitude: 28.102003,
    longitude: 30.754194,
    rating: 4.0,
    reviewCount: 936,
    cuisineType: { en: "Syrian / Fast Food", ar: "سوري / وجبات سريعة" },
    priceRange: { en: "Low to Mid", ar: "منخفض إلى متوسط" },
    openingHours: { en: "Mon–Sun 10:00 AM – 04:00 AM", ar: "الاثنين–الأحد ١٠:٠٠ ص – ٤:٠٠ ص" },
    specialties: [
      { en: "Shawarma", ar: "شاورما" },
      { en: "Broasted Chicken", ar: "بروستد" }
    ],
    center: { en: "New Minya", ar: "المنيا الجديدة" },
    contactInfo: {
      phone: { en: "01030022700", ar: "٠١٠٣٠٠٢٢٧٠٠" },
      email: ""
    },
    features: [
      { en: "Restroom", ar: "دورة مياه" }
    ]
  },
  {
    id: "set_elsham",
    name: { en: "Set El Sham", ar: "ست الشام" },
    description: {
      en: "Popular local restaurant offering Levantine & Egyptian specialties — grills, shawarma and family-style dishes.",
      ar: "مطعم شعبي يقدم أطباق شامية ومصرية مميزة — مشاوي، شاورما وأطباق عائلية."
    },
    imageUrl: "assets/images/set elsham.png",
    imageGallery: [
      "assets/images/ست الشام المنيا.jpg",
      "assets/images/images (2).jpg"
    ],
    menuUrl: "/assets/menus/set_elsham.pdf",
    latitude: 28.107,
    longitude: 30.75,
    rating: 4.1,
    reviewCount: 1779,
    cuisineType: { en: "Levantine / Egyptian", ar: "شامي / مصري" },
    priceRange: { en: "Low to Mid", ar: "منخفض إلى متوسط" },
    openingHours: { en: "11:00 AM – 03:00 AM", ar: "١١:٠٠ ص – ٣:٠٠ ص" },
    specialties: [
      { en: "Grills", ar: "مشاوي" },
      { en: "Shawarma", ar: "شاورما" },
      { en: "Family dishes", ar: "أطباق عائلية" }
    ],
    center: { en: "Minya", ar: "المنيا" },
    contactInfo: {
      phone: { en: "01060601600", ar: "٠١٠٦٠٦٠١٦٠٠" },
      email: ""
    },
    features: [
      { en: "Delivery", ar: "توصيل" },
      { en: "Indoor seating", ar: "جلسات داخلية" },
      { en: "Late-night service", ar: "خدمة ليلية" }
    ]
  },
  {
    id: "fresh_food_grills_minya",
    name: { en: "Fresh Food Grills", ar: "مطعم مشويات فريش فوود" },
    description: {
      en: "Grill restaurant offering mixed grills, kebabs and family platters in New Minya.",
      ar: "مطعم مشويات يقدم مشاوي متنوعة، كفتة وأسياخ وأطباق عائلية بالمنيا الجديدة."
    },
    imageUrl: "assets/images/2021-08-28.png",
    imageGallery: ["assets/images/2025-05-21.png"],
    menuUrl: "/assets/menus/fresh_food_grills_minya.pdf",
    latitude: 28.106,
    longitude: 30.751,
    rating: 4.7,
    reviewCount: 448,
    cuisineType: { en: "Grill / Egyptian", ar: "مشاوي / مصري" },
    priceRange: { en: "Low to Mid", ar: "منخفض إلى متوسط" },
    openingHours: { en: "11:30 AM – 03:00 AM", ar: "١١:٣٠ ص – ٣:٠٠ ص" },
    specialties: [
      { en: "Mixed Grills", ar: "مشاوي مشكلة" },
      { en: "Kebab & Skewers", ar: "كباب وأسياخ" }
    ],
    center: { en: "New Minya", ar: "المنيا الجديدة" },
    contactInfo: {
      phone: { en: "01020004495", ar: "٠١٠ ٢٠٠٠٤٤٩٥" },
      email: ""
    },
    features: [
      { en: "Delivery", ar: "توصيل" },
      { en: "Outdoor seating", ar: "جلسات خارجية" },
      { en: "Late-night service", ar: "خدمة ليلية" }
    ]
  },
  {
    id: "al_mohamady_minya",
    name: { en: "Al Mohamady Restaurant", ar: "مطعم المحمدى" },
    description: {
      en: "Traditional local restaurant in Hasib, serving Egyptian home-style dishes and grills.",
      ar: "مطعم محلي في حسيب يقدم أطباق مصرية منزلية ومشاوي."
    },
    imageUrl: "assets/images/unnamed (1).png",
    imageGallery: ["assets/images/unnamed (4).png"],
    menuUrl: "/assets/menus/al_mohamady_minya.pdf",
    latitude: 28.095,
    longitude: 30.762,
    rating: 3.9,
    reviewCount: 1983,
    cuisineType: { en: "Egyptian / Grill", ar: "مصري / مشاوي" },
    priceRange: { en: "Low", ar: "منخفض" },
    openingHours: { en: "08:00 AM – 04:00 AM", ar: "٨:٠٠ ص – ٤:٠٠ ص" },
    specialties: [
      { en: "Grills", ar: "مشاوي" },
      { en: "Home-style stews", ar: "طواجن وأكلات منزلية" }
    ],
    center: { en: "Hasib / Minya Center", ar: "حسيب / مركز المنيا" },
    contactInfo: {
      phone: { en: "0862359696", ar: "٠٨٦ ٢٣٥٩٦٩٦" },
      email: ""
    },
    features: [
      { en: "Takeaway", ar: "طلبات خارجية" },
      { en: "Outdoor seating", ar: "جلسات خارجية" }
    ]
  },
  {
    id: "city_crepe_minya",
    name: { en: "City Crepe", ar: "سيتي كريب" },
    description: {
      en: "Small creperie offering sweet & savory crepes, coffee and light snacks in Old Minya.",
      ar: "كريب صغير يقدم كريب حلو ومالح، قهوة وسناكات خفيفة في أول المنيا."
    },
    imageUrl: "assets/images/City crepe.png",
    imageGallery: [
      "assets/images/city-crepe_menu_1.jpg",
      "assets/images/city-crepe_menu_2.jpg",
      "assets/images/city-crepe_menu_3.jpg"
    ],
    menuUrl: "/assets/menus/city_crepe_minya.pdf",
    latitude: 28.097,
    longitude: 30.761,
    rating: 3.5,
    reviewCount: 122,
    cuisineType: { en: "Crepes / Cafe", ar: "كريب / مقهى" },
    priceRange: { en: "Low", ar: "منخفض" },
    openingHours: { en: "10:00 AM – 2:00 AM", ar: "١٠:٠٠ ص – ٢:٠٠ ص" },
    specialties: [
      { en: "Sweet Crepes", ar: "كريب حلو" },
      { en: "Savory Crepes", ar: "كريب مالح" }
    ],
    center: { en: "Old Minya", ar: "أول المنيا" },
    contactInfo: {
      phone: { en: "01099258903", ar: "٠١٠٩٩٢٥٨٩٠٣" },
      email: ""
    },
    features: [
      { en: "Takeaway", ar: "طلبات خارجية" },
      { en: "Indoor seating", ar: "جلسات داخلية" }
    ]
  },
  {
    id: "bondokah_minya",
    name: { en: "Bondokah Restaurant", ar: "مطعم بندقة" },
    description: {
      en: "Casual grill house known across Minya; serves koshary at some branches.",
      ar: "مطعم مشاوي شعبي وله فروع بالمنيا؛ يقدم كشري أحيانًا في بعض الفروع."
    },
    imageUrl: "assets/images/Bondokah Restaurant.jpg",
    imageGallery: ["/assets/images/470498594_933892548838992_4009911687513985324_n (1).jpg"],
    menuUrl: "/assets/menus/bondokah_minya.pdf",
    latitude: 28.10205,
    longitude: 30.754808,
    rating: 3.8,
    reviewCount: 2458,
    cuisineType: { en: "Egyptian / Grill", ar: "مصري / مشاوي" },
    priceRange: { en: "Affordable", ar: "مناسب" },
    openingHours: { en: "11:00 AM – 03:00 AM", ar: "١١:٠٠ ص – ٠٣:٠٠ ص" },
    specialties: [
      { en: "Mixed Grill", ar: "مشويات مشكلة" },
      { en: "Koshary", ar: "كشري" }
    ],
    center: { en: "Minya", ar: "المنيا" },
    contactInfo: {
      phone: { en: "086 2334141", ar: "٠٨٦ ٢٣٣٤١٤١" },
      email: ""
    },
    features: [
      { en: "Restroom", ar: "دورة مياه" },
      { en: "Delivery", ar: "توصيل" }
    ]
  },
  {
    id: "fresh_food_grill",
    name: { en: "Fresh Food Grill Restaurant", ar: "مطعم فريش فود جريل" },
    description: {
      en: "Mediterranean & Egyptian grilled dishes; listed on TripAdvisor.",
      ar: "أطباق مشوية متوسّطية ومصرية؛ مذكور في TripAdvisor وقوائم محلية."
    },
    imageUrl: "assets/images/Fresh Food Grill Restaurant_n.jpg",
    imageGallery: ["/assets/images/470498594_933892548838992_4009911687513985324_n (1).jpg"],
    menuUrl: "/assets/menus/fresh_food_grill.pdf",
    latitude: 28.073673,
    longitude: 30.816349,
    rating: 4.7,
    reviewCount: 448,
    cuisineType: { en: "Mediterranean / Grill", ar: "متوسطي / مشاوي" },
    priceRange: { en: "Mid-range", ar: "متوسط" },
    openingHours: { en: "12:00 PM – 01:00 AM", ar: "١٢:٠٠ م – ٠١:٠٠ ص" },
    specialties: [
      { en: "Mixed Grill", ar: "مشويات مشكلة" },
      { en: "Seafood platters", ar: "أطباق سي فود" }
    ],
    center: { en: "Minya", ar: "المنيا" },
    contactInfo: {
      phone: { en: "01020004495", ar: "٠١٠٢٠٠٠٤٤٩٥" },
      email: ""
    },
    features: [
      { en: "Restroom", ar: "دورة مياه" },
      { en: "Delivery", ar: "توصيل" }
    ]
  },
  {
    id: "cboat_minya",
    name: { en: "C-Boat", ar: "C-Boat" },
    description: {
      en: "Nile-side restaurant with views; evening dining spot in Minya.",
      ar: "مطعم على ضفاف النيل مع إطلالة؛ وجهة شائعة للعشاء في المنيا."
    },
    imageUrl: "assets/images/hotels/c-boat/c-boat3.jpg",
    imageGallery: [
      "/assets/images/menu 11.png",
      "/assets/images/menu 14.png",
      "/assets/images/menu 13 (2).png",
      "/assets/images/menu 6.png",
      "/assets/images/menu 18.png"
    ],
    menuUrl: "/assets/menus/cboat_minya.pdf",
    latitude: 28.102192,
    longitude: 30.758244,
    rating: 4.1,
    reviewCount: 802,
    cuisineType: { en: "Egyptian / Seafood", ar: "مصري / سي فود" },
    priceRange: { en: "Mid-range", ar: "متوسط" },
    openingHours: { en: "8:00 AM – 11:45 PM", ar: "٨:٠٠ ص – ١١:٤٥ م" },
    specialties: [
      { en: "Grilled Fish", ar: "سمك مشوي" }
    ],
    center: { en: "Corniche", ar: "الكورنيش" },
    contactInfo: {
      phone: { en: "", ar: "" },
      email: ""
    },
    features: [
      { en: "Nile View", ar: "إطلالة على النيل" },
      { en: "Restroom", ar: "دورة مياه" }
    ]
  },
  {
    id: "casa_bella_minya",
    name: { en: "Casa Bella Restaurant", ar: "كازا بيلا" },
    description: {
      en: "Casual restaurant offering Italian-inspired dishes, pizzas and desserts in Old Minya.",
      ar: "مطعم كاجوال يقدم أطباق إيطالية، بيتزا ومجموعة حلويات في أول المنيا."
    },
    imageUrl: "assets/images/unnamed (5).png",
    imageGallery: ["/assets/images/131098693_2747922352140036_7804884136602912632_o.png"],
    menuUrl: "/assets/menus/casa_bella_minya.pdf",
    latitude: 28.0975,
    longitude: 30.7605,
    rating: 4.4,
    reviewCount: 414,
    cuisineType: { en: "Italian / Pizza / Mediterranean", ar: "إيطالي / بيتزا / متوسطي" },
    priceRange: { en: "Mid", ar: "متوسط" },
    openingHours: { en: "10:00 AM – 02:00 AM", ar: "١٠:٠٠ ص – ٢:٠٠ ص" },
    specialties: [
      { en: "Pizza", ar: "بيتزا" },
      { en: "Pasta", ar: "باستا" }
    ],
    center: { en: "Taha Hussein / Old Minya", ar: "طه حسين / أول المنيا" },
    contactInfo: {
      phone: { en: "01003397905", ar: "٠١٠ ٠٣٣٩٧٩٠٥" },
      email: ""
    },
    features: [
      { en: "Indoor seating", ar: "جلسات داخلية" },
      { en: "Family friendly", ar: "مناسب للعائلات" },
      { en: "Takeaway", ar: "طلبات خارجية" }
    ]
  },
  {
    id: "el_baron_minya",
    name: { en: "El Baron", ar: "البارون" },
    description: {
      en: "Upper-floor dining near Teachers Union Tower; mixed menu and evening hours.",
      ar: "مطعم بالدور العلوي قرب برج نقابة المعلمين؛ قائمة متنوّعة وساعات مسائية."
    },
    imageUrl: "assets/images/unnamed.jpg",
    imageGallery: ["/assets/images/470498594_933892548838992_4009911687513985324_n (1).jpg"],
    menuUrl: "/assets/menus/el_baron_minya.pdf",
    latitude: 28.095285,
    longitude: 30.755815,
    rating: 4.1,
    reviewCount: 295,
    cuisineType: { en: "Mixed", ar: "متنوع" },
    priceRange: { en: "Mid-range", ar: "متوسط" },
    openingHours: { en: "Open 24 hours", ar: "يعمل على مدار 24 ساعة" },
    specialties: [
      { en: "Grilled Fish", ar: "سمك مشوي" },
      { en: "Seafood Platter", ar: "طبق سي فود" }
    ],
    center: { en: "Minya", ar: "المنيا" },
    contactInfo: {
      phone: { en: "0862334667", ar: "٠٨٦٢٣٣٤٦٦٧" },
      email: ""
    },
    features: [
      { en: "Restroom", ar: "دورة مياه" }
    ]
  },
  {
    id: "eltabei_minya",
    name: { en: "El Tabai", ar: "التابعي" },
    description: {
      en: "Serving traditional Egyptian street food and sandwiches around the clock.",
      ar: "نقدّم أشهى المأكولات الشعبية وجميع أنواع السندوتشات على مدار الساعة."
    },
    imageUrl: "assets/images/unnamed (2).png",
    imageGallery: ["assets/images/images (1).jpg"],
    menuUrl: "/assets/menus/eltabei_minya.pdf",
    latitude: 28.086694,
    longitude: 30.763122,
    rating: 3.9,
    reviewCount: 149,
    cuisineType: { en: "Egyptian Street Food", ar: "مأكولات شعبية" },
    priceRange: { en: "1–100 E£ per person", ar: "١–١٠٠ جنيه للفرد" },
    openingHours: { en: "Open 24 hours", ar: "يعمل على مدار 24 ساعة" },
    specialties: [
      { en: "Egyptian Sandwiches", ar: "سندوتشات مصرية" },
      { en: "Falafel & Beans", ar: "فلافل وفول" }
    ],
    center: { en: "Minya", ar: "المنيا" },
    contactInfo: {
      phone: { en: "01555724861", ar: "٠١٥٥٥٧٢٤٨٦١" },
      email: ""
    },
    features: [
      { en: "Cash only", ar: "الدفع نقدي فقط" },
      { en: "Open 24 hours", ar: "يعمل على مدار الساعة" }
    ]
  },
  {
    id: "orchid_palace_minya",
    name: { en: "Orchid Palace", ar: "قصر الاوركيد" },
    description: {
      en: "Large Nile-side restaurant & events venue; outdoor seating & seafood specialties.",
      ar: "مطعم كبير على النيل ومكان فعاليات؛ جلسات خارجية وتخصصات بحرية."
    },
    imageUrl: "assets/images/orchid_palace_minya.jpg",
    imageGallery: ["/assets/images/470498594_933892548838992_4009911687513985324_n (1).jpg"],
    menuUrl: "/assets/menus/orchid_palace_minya.pdf",
    latitude: 28.107476,
    longitude: 30.753097,
    rating: 3.6,
    reviewCount: 51,
    cuisineType: { en: "Mixed / Seafood", ar: "متنوع / أسماك" },
    priceRange: { en: "Mid-range to High", ar: "متوسط إلى مرتفع" },
    openingHours: { en: "10:00 AM – 12:00 AM", ar: "١٠:٠٠ ص – ١٢:٠٠ ص" },
    specialties: [
      { en: "Seafood", ar: "أسماك" }
    ],
    center: { en: "Corniche", ar: "الكورنيش" },
    contactInfo: {
      phone: { en: "01555544433", ar: "٠١٥٥٥٥٤٤٤٣٣" },
      email: ""
    },
    features: [
      { en: "Nile View", ar: "إطلالة على النيل" }
    ]
  },
  {
    id: "alkasrawy_minya",
    name: { en: "Al-Kasrawy", ar: "الكسراوى" },
    description: {
      en: "Popular crepes, pizzas and mixed grill spot in Minya.",
      ar: "مطعم يقدم كريب، بيتزا ومشاوي؛ مشهور محليًا."
    },
    imageUrl: "assets/images/alkasrawy_minya.jpg",
    imageGallery: ["/assets/images/470498594_933892548838992_4009911687513985324_n (1).jpg"],
    menuUrl: "/assets/menus/alkasrawy_minya.pdf",
    latitude: 28.094055,
    longitude: 30.758448,
    rating: 4.1,
    reviewCount: 10,
    cuisineType: { en: "Crepes / Pizza / Grill", ar: "كريب / بيتزا / مشاوي" },
    priceRange: { en: "Low to Mid", ar: "منخفض إلى متوسط" },
    openingHours: { en: "12:00 PM – 2:00 AM", ar: "١٢:٠٠ م – ٢:٠٠ ص" },
    specialties: [
      { en: "Crepes", ar: "كريب" },
      { en: "Stone-baked Pizza", ar: "بيتزا حجرية" }
    ],
    center: { en: "Minya", ar: "المنيا" },
    contactInfo: {
      phone: { en: "01004875750", ar: "٠١٠٠٤٨٧٥٧٥٠" },
      email: ""
    },
    features: [
      { en: "Delivery", ar: "توصيل" },
      { en: "Takeaway", ar: "تيك أواي" }
    ]
  },
  {
    id: "festival_crepiano_minya",
    name: { en: "Festival Crepiano", ar: "Festival Crepiano" },
    description: {
      en: "Crepes, desserts and fast casual active branch in Minya with delivery.",
      ar: "كريب وحلويات وسريع؛ فرع نشط بالمنيا مع أرقام توصيل."
    },
    imageUrl: "assets/images/f.jpg",
    imageGallery: ["/assets/images/470498594_933892548838992_4009911687513985324_n (1).jpg"],
    menuUrl: "/assets/menus/festival_crepiano_minya.pdf",
    latitude: 28.100365,
    longitude: 30.755116,
    rating: 3.9,
    reviewCount: 36,
    cuisineType: { en: "Crepes / Desserts", ar: "كريب / حلويات" },
    priceRange: { en: "Low to Mid", ar: "منخفض إلى متوسط" },
    openingHours: { en: "8:00 AM – 10:00 PM", ar: "٨:٠٠ ص – ١٠:٠٠ م" },
    specialties: [
      { en: "Filled Crepes", ar: "كريب محشو" },
      { en: "Pizza", ar: "بيتزا" }
    ],
    center: { en: "Minya", ar: "المنيا" },
    contactInfo: {
      phone: { en: "01013739999", ar: "٠١٠١٣٧٣٩٩٩٩" },
      email: ""
    },
    features: [
      { en: "Delivery", ar: "توصيل" },
      { en: "Takeaway", ar: "تيك أواي" }
    ]
  },
  {
    id: "house_crepe_minya",
    name: { en: "House Crepe", ar: "House Crepe" },
    description: {
      en: "Crepes & cafe branch in New Minya.",
      ar: "فرع كريب وكافيه بالمنيا الجديدة."
    },
    imageUrl: "assets/images/house_crepe_minya.jpg",
    imageGallery: ["/assets/images/470498594_933892548838992_4009911687513985324_n (1).jpg"],
    menuUrl: "/assets/menus/house_crepe_minya.pdf",
    latitude: 28.108784,
    longitude: 30.749385,
    rating: 3.9,
    reviewCount: 134,
    cuisineType: { en: "Crepes / Cafe", ar: "كريب / كافيه" },
    priceRange: { en: "Low to Mid", ar: "منخفض إلى متوسط" },
    openingHours: { en: "8:00 AM – 2:00 AM", ar: "٨:٠٠ ص – ٢:٠٠ ص" },
    specialties: [
      { en: "Filled Crepes", ar: "كريب محشو" }
    ],
    center: { en: "New Minya", ar: "المنيا الجديدة" },
    contactInfo: {
      phone: { en: "086 236 2252", ar: "٠٨٦ ٢٣٦ ٢٢٥٢" },
      email: ""
    },
    features: [
      { en: "Delivery", ar: "توصيل" },
      { en: "Takeaway", ar: "تيك أواي" }
    ]
  },
  {
    id: "saman_ala_asal_minya",
    name: { en: "Saman Ala Asal", ar: "سمن على عسل" },
    description: {
      en: "Desserts & sweets shop — active Facebook page and local delivery hotline.",
      ar: "محل حلويات؛ له صفحة فيسبوك نشطة وخط توصيل محلي."
    },
    imageUrl: "assets/images/سمن على عسل.jpg",
    imageGallery: ["/assets/images/470498594_933892548838992_4009911687513985324_n (1).jpg"],
    menuUrl: "/assets/menus/saman_ala_asal_minya.pdf",
    latitude: 28.11106,
    longitude: 30.750139,
    rating: 4.0,
    reviewCount: 6,
    cuisineType: { en: "Desserts / Sweets", ar: "حلويات" },
    priceRange: { en: "Low to Mid", ar: "منخفض إلى متوسط" },
    openingHours: { en: "10:00 AM – 1:00 AM", ar: "١٠:٠٠ ص – ١:٠٠ ص" },
    specialties: [
      { en: "Oriental Sweets", ar: "حلويات شرقية" }
    ],
    center: { en: "Minya", ar: "المنيا" },
    contactInfo: {
      phone: { en: "16912", ar: "١٦٩١٢" },
      email: ""
    },
    features: [
      { en: "Delivery", ar: "توصيل" },
      { en: "Takeaway", ar: "تيك أواي" }
    ]
  },
  {
    id: "tallah_minya",
    name: { en: "Tallah Restaurant & Café", ar: "مطعم وكافية طلة" },
    description: {
      en: "Nile-side café and restaurant in Minya on the Corniche, great view and cozy ambiance.",
      ar: "كافية ومطعم على كورنيش المنيا، إطلالة على النيل وجو مريح."
    },
    imageUrl: "assets/images/tallah_minya.jpg",
    imageGallery: ["/assets/images/470498594_933892548838992_4009911687513985324_n (1).jpg"],
    menuUrl: "/assets/menus/tallah_minya.pdf",
    latitude: 28.108058,
    longitude: 30.752718,
    rating: 5.0,
    reviewCount: 2,
    cuisineType: { en: "Café / Mixed", ar: "كافيه / متنوع" },
    priceRange: { en: "Mid-range", ar: "متوسط" },
    openingHours: { en: "10:00 AM – 12:00 AM", ar: "١٠:٠٠ ص – ١٢:٠٠ ص" },
    specialties: [
      { en: "Grilled Fish", ar: "سمك مشوي" },
      { en: "Coffee", ar: "قهوة" }
    ],
    center: { en: "Corniche", ar: "الكورنيش" },
    contactInfo: {
      phone: { en: "01044844052", ar: "٠١٠٤٤٨٤٤٠٥٢" },
      email: ""
    },
    features: [
      { en: "Nile View", ar: "إطلالة على النيل" },
      { en: "Outdoor Seating", ar: "جلسات خارجية" }
    ]
  },
  {
    id: "arkan_minya",
    name: { en: "Arkan Restaurant", ar: "مطعم أركان" },
    description: {
      en: "Popular local restaurant in Minya city center serving grilled and family dishes.",
      ar: "مطعم شعبي في مركز المنيا يقدم مشاوي وأطباق عائلية متنوعة."
    },
    imageUrl: "assets/images/unnamed (6).png",
    imageGallery: [
      "assets/images/2023-01-03.png",
      "assets/images/unnamed (7).jpg",
      "assets/images/unnamed (8).jpg"
    ],
    menuUrl: "/assets/menus/arkan_minya.pdf",
    latitude: 28.0955,
    longitude: 30.7605,
    rating: 4.3,
    reviewCount: 855,
    cuisineType: { en: "Grill / Local", ar: "مشاوي / محلي" },
    priceRange: { en: "Low to Mid", ar: "منخفض إلى متوسط" },
    openingHours: { en: "11:00 AM – 12:00 AM", ar: "١١:٠٠ ص – ١٢:٠٠ ص" },
    specialties: [
      { en: "Grills", ar: "مشاوي" }
    ],
    center: { en: "Minya Center", ar: "مركز المنيا" },
    contactInfo: {
      phone: { en: "01093337343", ar: "٠١٠٩٣٣٣٧٣٤٣" },
      email: ""
    },
    features: [
      { en: "Takeaway", ar: "طلبات خارجية" },
      { en: "Indoor seating", ar: "جلسات داخلية" }
    ]
  },
  {
    id: "see_foul_minya",
    name: { en: "See Foul", ar: "سي فول" },
    description: {
      en: "Traditional Egyptian restaurant specializing in ful, taameya and classic breakfast on the Corniche.",
      ar: "مطعم مصري تقليدي متخصص في الفول والطعمية وأطباق الإفطار على الكورنيش."
    },
    imageUrl: "assets/images/unnamed (10).jpg",
    imageGallery: ["assets/images/unnamed (11).jpg"],
    menuUrl: "/assets/menus/see_foul_minya.pdf",
    latitude: 28.098,
    longitude: 30.7615,
    rating: 3.9,
    reviewCount: 862,
    cuisineType: { en: "Egyptian / Breakfast", ar: "مصري / إفطار" },
    priceRange: { en: "Low", ar: "منخفض" },
    openingHours: { en: "Open 24 hours", ar: "يعمل على مدار 24 ساعة" },
    specialties: [
      { en: "Ful", ar: "فول" },
      { en: "Taameya", ar: "طعمية" }
    ],
    center: { en: "Corniche / Minya Center", ar: "الكورنيش / مركز المنيا" },
    contactInfo: {
      phone: { en: "0862324999", ar: "٠٨٦ ٢٣٢٤٩٩٩" },
      email: ""
    },
    features: [
      { en: "Takeaway", ar: "طلبات خارجية" },
      { en: "Outdoor seating", ar: "جلسات خارجية" }
    ]
  },
  {
    id: "famous_burger_minya",
    name: { en: "Famous Burger", ar: "فيماس برجر" },
    description: {
      en: "Casual burger joint known for classic burgers, fries and quick takeaway on Taha Hussein Street.",
      ar: "مطعم برجر بسيط يشتهر بالبرجر الكلاسيكي والبطاطس في شارع طه حسين."
    },
    imageUrl: "assets/images/unnamed (13).jpg",
    imageGallery: [
      "assets/images/unnamed (12).jpg",
      "assets/images/202678602_125463026379368_955375323180507063_n.png"
    ],
    menuUrl: "/assets/menus/famous_burger_minya.pdf",
    latitude: 28.0975,
    longitude: 30.7608,
    rating: 4.4,
    reviewCount: 165,
    cuisineType: { en: "Burgers / Fast Food", ar: "برجر / وجبات سريعة" },
    priceRange: { en: "Low to Mid", ar: "منخفض إلى متوسط" },
    openingHours: { en: "11:00 AM – 2:00 AM", ar: "١١:٠٠ ص – ٢:٠٠ ص" },
    specialties: [
      { en: "Burgers", ar: "برجر" }
    ],
    center: { en: "Taha Hussein, Minya", ar: "طه حسين، أول المنيا" },
    contactInfo: {
      phone: { en: "", ar: "" },
      email: ""
    },
    features: [
      { en: "Takeaway", ar: "طلبات خارجية" },
      { en: "Fast service", ar: "خدمة سريعة" }
    ]
  },
  {
    id: "mcdonalds_minya",
    name: { en: "McDonald's Minya", ar: "ماكدونالدز المنيا" },
    description: {
      en: "International fast-food chain serving burgers, fries, and coffee at Nefertiti Hotel.",
      ar: "سلسلة الوجبات السريعة العالمية تقدم البرجر والبطاطس والقهوة داخل فندق نفرتيتي."
    },
    imageUrl: "assets/images/unnamed (14).jpg",
    imageGallery: [
      "assets/images/mcdonalds-minya_1.jpg",
      "assets/images/mcdonalds-minya_2.jpg"
    ],
    menuUrl: "/assets/menus/mcdonalds_minya.pdf",
    latitude: 28.0959,
    longitude: 30.7598,
    rating: 4.2,
    reviewCount: 1315,
    cuisineType: { en: "Fast Food / Burgers", ar: "وجبات سريعة / برجر" },
    priceRange: { en: "Mid", ar: "متوسط" },
    openingHours: { en: "07:00 AM – 03:00 AM", ar: "٧:٠٠ ص – ٣:٠٠ ص" },
    specialties: [
      { en: "Burgers", ar: "برجر" },
      { en: "Fries", ar: "بطاطس" }
    ],
    center: { en: "Corniche / Nefertiti Hotel", ar: "كورنيش المنيا / فندق نفرتيتي" },
    contactInfo: {
      phone: { en: "0221600377", ar: "٠٢ ٢١٦٠٠٣٧٧" },
      email: ""
    },
    features: [
      { en: "Delivery", ar: "توصيل" },
      { en: "Drive-thru", ar: "طلب من السيارة" }
    ]
  },
  {
    id: "pizza_suwaisy_minya",
    name: { en: "Pizza & Pastries El-Suwaisy", ar: "بيتزا وفطائر السويسي" },
    description: {
      en: "Local pizzeria and pastry shop in Minya serving pizzas and savory pies.",
      ar: "محل بيتزا وفطائر محلي في المنيا يقدم بيتزا وفطائر مملحة."
    },
    imageUrl: "assets/images/unnamed (50).jpg",
    imageGallery: [
      "assets/images/unnamed (51).jpg",
      "assets/images/unnamed (52).jpg",
      "assets/images/unnamed (53).jpg"
    ],
    menuUrl: "/assets/menus/pizza_suwaisy_minya.pdf",
    latitude: 28.095,
    longitude: 30.76,
    rating: 3.7,
    reviewCount: 185,
    cuisineType: { en: "Pizza & Pastries", ar: "بيتزا وفطائر" },
    priceRange: { en: "Affordable", ar: "اقتصادي" },
    openingHours: { en: "10:00 AM – 12:00 AM", ar: "١٠:٠٠ ص – ١٢:٠٠ ص" },
    specialties: [
      { en: "Wood-fired Pizza", ar: "بيتزا" },
      { en: "Savory Pies", ar: "فطائر مملحة" }
    ],
    center: { en: "Minya Center", ar: "مركز المنيا" },
    contactInfo: {
      phone: { en: "0862368442", ar: "٠٨٦٢٣٦٨٤٤٢" },
      email: ""
    },
    features: [
      { en: "Dine-in & takeaway", ar: "تناول داخل المطعم وسفري" }
    ]
  },
  {
    id: "doctorbox_minya",
    name: { en: "DOCTOR BOX Fried Chicken & Burger", ar: "دكتور بوكس - فرايد تشيكن وبرجر" },
    description: {
      en: "Popular fast-food spot in Minya specializing in fried chicken and burgers.",
      ar: "مطعم فاست فود شهير بالمنيا متخصص في الفرايد تشيكن والبرجر."
    },
    imageUrl: "assets/images/unnamed (57).jpg",
    imageGallery: ["/assets/images/470498594_933892548838992_4009911687513985324_n (1).jpg"],
    menuUrl: "/assets/menus/doctorbox_minya.pdf",
    latitude: 28.0985,
    longitude: 30.7565,
    rating: 4.7,
    reviewCount: 513,
    cuisineType: { en: "Fried Chicken & Burgers", ar: "فرايد تشيكن وبرجر" },
    priceRange: { en: "200–400 E£ per person", ar: "٢٠٠–٤٠٠ جنيه للفرد" },
    openingHours: { en: "12:00 PM – 3:00 AM", ar: "١٢:٠٠ م – ٣:٠٠ ص" },
    specialties: [
      { en: "Fried Chicken Buckets", ar: "دلاء فرايد تشيكن" },
      { en: "Signature Burgers", ar: "برجر مميز" }
    ],
    center: { en: "Old Minya", ar: "أول المنيا" },
    contactInfo: {
      phone: { en: "01501010158", ar: "٠١٥٠١٠١٠١٥٨" },
      email: ""
    },
    features: [
      { en: "Late-night service", ar: "خدمة لساعات متأخرة" },
      { en: "Takeaway & delivery", ar: "سفري وتوصيل" }
    ]
  },
  {
    id: "cesar_cafe_minya",
    name: { en: "Cesar Cafe", ar: "سيزار كافية" },
    description: {
      en: "Riverside cafe on Minya Corniche offering coffee, light meals and pastries.",
      ar: "كافية على كورنيش النيل بالمنيا تقدم القهوة، وجبات خفيفة ومعجنات."
    },
    imageUrl: "assets/images/2024-06-26.png",
    imageGallery: [
      "assets/images/cesar_cafe_1.jpg",
      "assets/images/cesar_cafe_2.jpg"
    ],
    menuUrl: "/assets/menus/cesar_cafe_minya.pdf",
    latitude: 28.0955,
    longitude: 30.759,
    rating: 3.9,
    reviewCount: 713,
    cuisineType: { en: "Cafe", ar: "كافية" },
    priceRange: { en: "Mid-range", ar: "متوسط" },
    openingHours: { en: "9:00 AM – 1:00 AM", ar: "٩:٠٠ ص – ١:٠٠ ص" },
    specialties: [
      { en: "Specialty Coffee", ar: "قهوة مميزة" },
      { en: "Pastries & Desserts", ar: "معجنات وحلويات" }
    ],
    center: { en: "Minya Center", ar: "مركز المنيا" },
    contactInfo: {
      phone: { en: "01202191191", ar: "٠١٢٠٢١٩١١٩١" },
      email: ""
    },
    features: [
      { en: "Riverside seating", ar: "جلسات على النيل" },
      { en: "Wi-Fi", ar: "واي فاي" }
    ]
  },
  {
    id: "brego_minya",
    name: { en: "Brego", ar: "بريجو" },
    description: {
      en: "24-hour restaurant in Minya offering a variety of casual dining dishes and quick bites.",
      ar: "مطعم يعمل على مدار الساعة في المنيا يقدم أطباق كاجوال وسندوتشات ووجبات سريعة."
    },
    imageUrl: "assets/images/unnamed (29).jpg",
    imageGallery: [
      "assets/images/unnamed (30).jpg",
      "assets/images/unnamed (31).jpg",
      "assets/images/unnamed (33).jpg"
    ],
    menuUrl: "/assets/menus/brego_minya.pdf",
    latitude: 28.098,
    longitude: 30.757,
    rating: 4.1,
    reviewCount: 535,
    cuisineType: { en: "Casual Dining", ar: "مطاعم كاجوال" },
    priceRange: { en: "Mid-range", ar: "متوسط" },
    openingHours: { en: "Open 24 hours", ar: "يعمل على مدار 24 ساعة" },
    specialties: [
      { en: "Sandwiches & Fast Meals", ar: "سندوتشات ووجبات سريعة" },
      { en: "Grills", ar: "مشويات" }
    ],
    center: { en: "Old Minya", ar: "أول المنيا" },
    contactInfo: {
      phone: { en: "", ar: "" },
      email: ""
    },
    features: [
      { en: "Open 24 hours", ar: "يعمل على مدار الساعة" }
    ]
  },
  {
    id: "carbiano_minya",
    name: { en: "Carbiano", ar: "كربيانو" },
    description: {
      en: "Casual dining restaurant in Minya offering fast food and grilled dishes with comfortable seating.",
      ar: "مطعم كاجوال في المنيا يقدم وجبات سريعة ومشويات متنوعة مع جلسات مريحة."
    },
    imageUrl: "assets/images/unnamed (19).jpg",
    imageGallery: [
      "assets/images/2024-12-17.png",
      "assets/images/unnamed (20).jpg",
      "assets/images/unnamed (21).jpg"
    ],
    menuUrl: "/assets/menus/carbiano_minya.pdf",
    latitude: 28.10992,
    longitude: 30.75045,
    rating: 3.7,
    reviewCount: 475,
    cuisineType: { en: "Fast Food & Grills", ar: "وجبات سريعة ومشويات" },
    priceRange: { en: "Mid-range", ar: "متوسط" },
    openingHours: { en: "11:00 AM – 1:00 AM", ar: "١١:٠٠ ص – ١:٠٠ ص" },
    specialties: [
      { en: "Burgers", ar: "برجر" },
      { en: "Grilled Chicken", ar: "دجاج مشوي" }
    ],
    center: { en: "Minya", ar: "المنيا" },
    contactInfo: {
      phone: { en: "01064116662", ar: "٠١٠٦٤١١٦٦٦٢" },
      email: ""
    },
    features: [
      { en: "Family seating", ar: "جلسات عائلية" }
    ]
  },
  {
    id: "mr_chix_minya",
    name: { en: "Mr. Chix", ar: "مستر شيكس" },
    description: {
      en: "Popular fried chicken and sandwich restaurant on Taha Hussein Street.",
      ar: "مطعم دجاج مقلي وسندوتشات شهير في شارع طه حسين."
    },
    imageUrl: "assets/images/unnamed (15).jpg",
    imageGallery: [
      "assets/images/unnamed (16).jpg",
      "assets/images/unnamed (18).jpg"
    ],
    menuUrl: "/assets/menus/mr_chix_minya.pdf",
    latitude: 28.0972,
    longitude: 30.7609,
    rating: 4.2,
    reviewCount: 154,
    cuisineType: { en: "Fried Chicken / Fast Food", ar: "دجاج مقلي / وجبات سريعة" },
    priceRange: { en: "Low to Mid", ar: "منخفض إلى متوسط" },
    openingHours: { en: "12:00 PM – 02:00 AM", ar: "١٢:٠٠ م – ٢:٠٠ ص" },
    specialties: [
      { en: "Fried Chicken", ar: "دجاج مقلي" },
      { en: "Chicken Sandwiches", ar: "ساندوتشات دجاج" }
    ],
    center: { en: "Taha Hussein, Minya", ar: "طه حسين، مركز المنيا" },
    contactInfo: {
      phone: { en: "01029292199", ar: "٠١٠٢٩٢٩٢١٩٩" },
      email: ""
    },
    features: [
      { en: "Delivery", ar: "توصيل" },
      { en: "Takeaway", ar: "طلبات خارجية" }
    ]
  }
];

const postData = Buffer.from(JSON.stringify(RAW_RESTAURANTS), 'utf-8');

const options = {
  hostname: 'localhost',
  port: 7123,
  path: '/api/Restaurants/bulk',
  method: 'POST',
  rejectUnauthorized: false,
  headers: {
    'Content-Type': 'application/json; charset=utf-8',
    'Content-Length': postData.length
  }
};

console.log(`Starting bulk insertion for ${RAW_RESTAURANTS.length} restaurants...`);

const req = https.request(options, (res) => {
  let responseBody = '';
  res.setEncoding('utf8');
  res.on('data', (chunk) => responseBody += chunk);
  res.on('end', () => {
    console.log(`Status Code: ${res.statusCode}`);
    try {
      console.log('Response:', JSON.parse(responseBody));
    } catch {
      console.log('Response Body:', responseBody);
    }
  });
});

req.on('error', (e) => {
  console.error('Request failed:', e.message);
});

req.write(postData);
req.end();