const https = require('https');

const HOTELS = [
  {
    id: "2",
    name: { en: "Grand Aton", ar: "جراند آتون" },
    description: { en: "Hotel on the Corniche (Minya).", ar: "فندق على الكورنيش (المنيا)." },
    imageUrl: "/assets/images/hotels/Aton/aton1.jpg",
    imageGallery: [
      "/assets/images/hotels/Aton/aton1.jpg",
      "/assets/images/hotels/Aton/aton2.jpg",
      "/assets/images/hotels/Aton/aton3.jpg",
      "/assets/images/hotels/Aton/aton4.jpg"
    ],
    latitude: 28.113914,
    longitude: 30.751081,
    rating: 3.5,
    reviewCount: 2096,
    priceRange: { en: "Moderate", ar: "متوسط" },
    amenities: [
      { en: "Free WiFi", ar: "واي فاي مجاني" },
      { en: "Swimming Pool", ar: "حمام سباحة" },
      { en: "Restaurant", ar: "مطعم" },
      { en: "Parking", ar: "موقف سيارات" }
    ],
    roomTypes: [],
    contactInfo: {
      phone: { en: "010 00308020", ar: "010 00308020" },
      email: { en: "", ar: "" },
      website: { en: "", ar: "" }
    },
    starRating: 3
  },
  {
    id: "3",
    name: { en: "Horus", ar: "حورس" },
    description: { en: "Hotel on the Corniche (Minya).", ar: "فندق على الكورنيش (المنيا)." },
    imageUrl: "/assets/images/hotels/Horus/horus.jpg",
    imageGallery: [
      "/assets/images/hotels/Horus/horus.jpg",
      "/assets/images/hotels/Horus/horus1.jpg",
      "/assets/images/hotels/Horus/horus2.jpg",
      "/assets/images/hotels/Horus/horus3.jpg",
      "/assets/images/hotels/Horus/horus4.jpg",
      "/assets/images/hotels/Horus/horus5.jpg",
      "/assets/images/hotels/Horus/horus6.jpg"
    ],
    latitude: 28.115338,
    longitude: 30.750456,
    rating: 3.9,
    reviewCount: 4400,
    priceRange: { en: "Moderate", ar: "متوسط" },
    amenities: [
      { en: "Free parking", ar: "موقف سيارات مجاني" },
      { en: "Free internet", ar: "إنترنت مجاني" },
      { en: "Pool", ar: "مسبح" },
      { en: "Free breakfast", ar: "إفطار مجاني" },
      { en: "Bar / lounge", ar: "بار / صالة" },
      { en: "Restaurant", ar: "مطعم" },
      { en: "Children Activities", ar: "أنشطة للأطفال" }
    ],
    roomTypes: [],
    contactInfo: {
      phone: { en: "086/2316660", ar: "086/2316660" },
      email: { en: "horusresortmenia@yahoo.com", ar: "horusresortmenia@yahoo.com" },
      website: { en: "http://www.horusresortmenia.com", ar: "http://www.horusresortmenia.com" }
    },
    starRating: 4
  },
  {
    id: "4",
    name: { en: "Savoy", ar: "سافوي" },
    description: { en: "Hotel at El Mahatta Square (Minya).", ar: "فندق في ميدان المحطة (المنيا)." },
    imageUrl: "/assets/images/hotels/Savoy.png",
    imageGallery: ["/assets/images/hotels/Savoy.png"],
    latitude: 28.097318,
    longitude: 30.754475,
    rating: 4.5,
    reviewCount: 182,
    priceRange: { en: "75$", ar: "٧٥ دولار" },
    amenities: [
      { en: "Restaurant", ar: "مطعم" },
      { en: "Balcony", ar: "شرفة" },
      { en: "Private bathroom", ar: "حمام خاص" },
      { en: "Air conditioning", ar: "تكييف" },
      { en: "Free WiFi", ar: "واي فاي مجاني" },
      { en: "View", ar: "إطلالة" },
      { en: "Flat-screen TV", ar: "تلفزيون بشاشة مسطحة" },
      { en: "Parking", ar: "موقف سيارات" },
      { en: "Room service", ar: "خدمة الغرف" }
    ],
    roomTypes: [],
    contactInfo: {
      phone: { en: "086/2343494", ar: "086/2343494" },
      email: { en: "Reservation@savoy-elminya.com", ar: "Reservation@savoy-elminya.com" },
      website: { en: "https://www.savoy-elminya.com", ar: "https://www.savoy-elminya.com" }
    },
    starRating: 4
  },
  {
    id: "5",
    name: { en: "Armed Forces Hotel", ar: "فندق القوات المسلحة" },
    description: { en: "Hotel on East Nile (Minya).", ar: "فندق على شرق النيل (المنيا)." },
    imageUrl: "/assets/images/hotels/Armed Forces Hotel.jpg",
    imageGallery: ["/assets/images/hotels/Armed Forces Hotel.jpg"],
    latitude: 28.091573,
    longitude: 30.772246,
    rating: 3.9,
    reviewCount: 373,
    priceRange: { en: "81$", ar: "٨١ دولار" },
    amenities: [
      { en: "Paid public parking on-site", ar: "موقف عام مدفوع في الموقع" },
      { en: "Free High Speed Internet", ar: "إنترنت عالي السرعة مجانًا" },
      { en: "Sauna", ar: "ساونا" },
      { en: "Pool", ar: "مسبح" },
      { en: "Restaurant", ar: "مطعم" },
      { en: "Bowling", ar: "بولينج" },
      { en: "Squash", ar: "اسكواش" }
    ],
    roomTypes: [],
    contactInfo: {
      phone: { en: "086/2366274", ar: "086/2366274" },
      email: { en: "marketing@afh.jo", ar: "marketing@afh.jo" },
      website: { en: "https://armedforceshotel.com", ar: "https://armedforceshotel.com" }
    },
    starRating: 3
  },
  {
    id: "6",
    name: { en: "C-Boat (Floating Hotel)", ar: "سي بوت (فندق عائم)" },
    description: { en: "Floating hotel at the Evangelical Authority marina (Minya).", ar: "فندق عائم عند مرسى الهيئة الإنجيلية (المنيا)." },
    imageUrl: "/assets/images/hotels/c-boat/c-boat1.jpg",
    imageGallery: [
      "/assets/images/hotels/c-boat/c-boat1.jpg",
      "/assets/images/hotels/c-boat/c-boat2.jpg",
      "/assets/images/hotels/c-boat/c-boat3.jpg",
      "/assets/images/hotels/c-boat/c-boat4.jpg",
      "/assets/images/hotels/c-boat/c-boat.jpg"
    ],
    latitude: 28.102177,
    longitude: 30.758276,
    rating: 4.1,
    reviewCount: 802,
    priceRange: { en: "60$", ar: "٦٠ دولار" },
    amenities: [
      { en: "Free Wifi", ar: "واي فاي مجاني" },
      { en: "Private bathroom", ar: "حمام خاص" },
      { en: "Air conditioning", ar: "تكييف" },
      { en: "View", ar: "إطلالة" },
      { en: "Terrace", ar: "تراس" }
    ],
    roomTypes: [],
    contactInfo: {
      phone: { en: "01278722340", ar: "01278722340" },
      email: { en: "dahabiah@ceoss.org.eg", ar: "dahabiah@ceoss.org.eg" },
      website: { en: "", ar: "" }
    },
    starRating: 3
  },
  {
    id: "7",
    name: { en: "Holy Family", ar: "العائلة المقدسة" },
    description: { en: "Hotel at Jabal al-Tair (Smalout).", ar: "فندق في جبل الطير (سمالوط)." },
    imageUrl: "/assets/images/hotels/mokadas/mokadas.jpg",
    imageGallery: [
      "/assets/images/hotels/mokadas/mokadas23.jpg",
      "/assets/images/hotels/mokadas/mokadas14.jpg",
      "/assets/images/hotels/mokadas/mokadas1.jpg",
      "/assets/images/hotels/mokadas/mokadas12.jpg",
      "/assets/images/hotels/mokadas/mokadas4.jpg"
    ],
    latitude: 28.3336,
    longitude: 30.7331,
    rating: 4.4,
    reviewCount: 100,
    priceRange: { en: "130$", ar: "١٣٠ دولار" },
    amenities: [
      { en: "Restaurant", ar: "مطعم" },
      { en: "Balcony", ar: "شرفة" },
      { en: "Private bathroom", ar: "حمام خاص" },
      { en: "Air conditioning", ar: "تكييف" },
      { en: "Free WiFi", ar: "واي فاي مجاني" },
      { en: "Parking", ar: "موقف سيارات" }
    ],
    roomTypes: [],
    contactInfo: {
      phone: { en: "01090390178", ar: "01090390178" },
      email: { en: "Reservation@holyfamilyhotel.net", ar: "Reservation@holyfamilyhotel.net" },
      website: { en: "https://holyfamilyhotel.net", ar: "https://holyfamilyhotel.net" }
    },
    starRating: 3
  },
  {
    id: "8",
    name: { en: "Cleopatra", ar: "كليوباترا" },
    description: { en: "Hotel on Taha Hussein St (Minya).", ar: "فندق في شارع طه حسين (المنيا)." },
    imageUrl: "/assets/images/hotels/cleo.png",
    imageGallery: ["/assets/images/hotels/cleo.png"],
    latitude: 28.112403,
    longitude: 30.749438,
    rating: 3.5,
    reviewCount: 1056,
    priceRange: { en: "Budget", ar: "اقتصادي" },
    amenities: [
      { en: "Laundry Service", ar: "خدمة غسيل الملابس" }
    ],
    roomTypes: [],
    contactInfo: {
      phone: { en: "086/2370800", ar: "086/2370800" },
      email: { en: "info@cleopatra.com", ar: "info@cleopatra.com" },
      website: { en: "", ar: "" }
    },
    starRating: 3
  },
  {
    id: "9",
    name: { en: "Lotus", ar: "لوتس" },
    description: { en: "Hotel on Port Said St (Minya).", ar: "فندق في شارع بورسعيد (المنيا)." },
    imageUrl: "/assets/images/hotels/Lotus.png",
    imageGallery: ["/assets/images/hotels/Lotus.png"],
    latitude: 28.101631,
    longitude: 30.752481,
    rating: 2.0,
    reviewCount: 12,
    priceRange: { en: "Budget", ar: "اقتصادي" },
    amenities: [],
    roomTypes: [],
    contactInfo: {
      phone: { en: "086/2364541", ar: "086/2364541" },
      email: { en: "Loutsnk1965@gmail.com", ar: "Loutsnk1965@gmail.com" },
      website: { en: "", ar: "" }
    },
    starRating: 2
  },
  {
    id: "10",
    name: { en: "Al Shatee (The Beach)", ar: "الشاطئ" },
    description: { en: "Hotel on El Gomhoureya St (Minya).", ar: "فندق في شارع الجمهورية (المنيا)." },
    imageUrl: "/assets/images/hotels/Al Shatee.jpg",
    imageGallery: ["/assets/images/hotels/Al Shatee.jpg"],
    latitude: 28.1032,
    longitude: 30.7511,
    rating: 2.5,
    reviewCount: 20,
    priceRange: { en: "Budget", ar: "اقتصادي" },
    amenities: [],
    roomTypes: [],
    contactInfo: {
      phone: { en: "086/2362307", ar: "086/2362307" },
      email: { en: "", ar: "" },
      website: { en: "", ar: "" }
    },
    starRating: 2
  },
  {
    id: "11",
    name: { en: "Ibn Khasib", ar: "ابن خصيب" },
    description: { en: "Hotel on Ragheb St (Minya).", ar: "فندق في شارع راغب (المنيا)." },
    imageUrl: "/assets/images/hotels/abn alkseb.jpg",
    imageGallery: ["/assets/images/hotels/abn alkseb.jpg"],
    latitude: 28.09681,
    longitude: 30.75541,
    rating: 3.0,
    reviewCount: 45,
    priceRange: { en: "Budget", ar: "اقتصادي" },
    amenities: [],
    roomTypes: [
      { en: "Double Room", ar: "غرفة مزدوجة" },
      { en: "2 Single beds", ar: "سريران فرديان" },
      { en: "1 Double bed", ar: "سرير مزدوج" }
    ],
    contactInfo: {
      phone: { en: "086/2364535", ar: "086/2364535" },
      email: { en: "", ar: "" },
      website: { en: "", ar: "" }
    },
    starRating: 3
  },
  {
    id: "12",
    name: { en: "Akhenaton", ar: "اخناتون" },
    description: { en: "Hotel on the Corniche (Minya), categorized as popular.", ar: "فندق على الكورنيش (المنيا)، مصنف كفندق شعبي." },
    imageUrl: "/assets/images/hotels/Akhenaton.jpg",
    imageGallery: ["/assets/images/hotels/Akhenaton.jpg"],
    latitude: 28.100132,
    longitude: 30.749,
    rating: 3.4,
    reviewCount: 375,
    priceRange: { en: "Budget", ar: "اقتصادي" },
    amenities: [
      { en: "Parking Free", ar: "موقف سيارات مجاني" },
      { en: "24-hour front desk", ar: "مكتب استقبال على مدار ٢٤ ساعة" },
      { en: "Wi-Fi in public areas", ar: "واي فاي في المناطق العامة" },
      { en: "Restaurant", ar: "مطعم" },
      { en: "Room service", ar: "خدمة الغرف" }
    ],
    roomTypes: [
      { en: "Double Room", ar: "غرفة مزدوجة" },
      { en: "Single Room", ar: "غرفة مفردة" },
      { en: "Triple Room", ar: "غرفة ثلاثية" }
    ],
    contactInfo: {
      phone: { en: "086/2365918", ar: "086/2365918" },
      email: { en: "", ar: "" },
      website: { en: "http://kingakhenatonhotel.com", ar: "http://kingakhenatonhotel.com" }
    },
    starRating: 3
  },
  {
    id: "13",
    name: { en: "Omar Khayyam", ar: "عمر الخيام" },
    description: { en: "Hotel on Damran St (Minya), popular category.", ar: "فندق في شارع دمران (المنيا)، فئة شعبية." },
    imageUrl: "/assets/images/hotels/Omar Khayyam.png",
    imageGallery: ["/assets/images/hotels/Omar Khayyam.png"],
    latitude: 28.099108,
    longitude: 30.758577,
    rating: 3.8,
    reviewCount: 66,
    priceRange: { en: "Budget", ar: "اقتصادي" },
    amenities: [
      { en: "Airport shuttle service", ar: "خدمة نقل المطار" },
      { en: "Room service", ar: "خدمة الغرف" },
      { en: "Free Wi-Fi", ar: "واي فاي مجاني" },
      { en: "Breakfast", ar: "إفطار" }
    ],
    roomTypes: [
      { en: "Deluxe Twin Room", ar: "غرفة ديلوكس توأم" },
      { en: "Deluxe Suite", ar: "جناح ديلوكس" },
      { en: "Deluxe Double Room", ar: "غرفة ديلوكس مزدوجة" },
      { en: "Deluxe Single Room", ar: "غرفة ديلوكس مفردة" }
    ],
    contactInfo: {
      phone: { en: "086/2365666", ar: "086/2365666" },
      email: { en: "", ar: "" },
      website: { en: "", ar: "" }
    },
    starRating: 2
  },
  {
    id: "14",
    name: { en: "Al Nile", ar: "النيل" },
    description: { en: "Hotel on Taha Hussein St (Minya), popular category.", ar: "فندق في شارع طه حسين (المنيا)، فئة شعبية." },
    imageUrl: "/assets/images/hotels/Al Nile.jpg",
    imageGallery: ["/assets/images/hotels/Al Nile.jpg"],
    latitude: 28.100132,
    longitude: 30.749,
    rating: 2.0,
    reviewCount: 15,
    priceRange: { en: "Budget", ar: "اقتصادي" },
    amenities: [],
    roomTypes: [],
    contactInfo: {
      phone: { en: "086/2363204", ar: "086/2363204" },
      email: { en: "", ar: "" },
      website: { en: "", ar: "" }
    },
    starRating: 2
  },
  {
    id: "15",
    name: { en: "Palace", ar: "بالاس" },
    description: { en: "Hotel at Palace Square (Minya), popular category.", ar: "فندق في ميدان بالاس (المنيا)، فئة شعبية." },
    imageUrl: "/assets/images/hotels/Palace.jpg",
    imageGallery: ["/assets/images/hotels/Palace.jpg"],
    latitude: 28.098467,
    longitude: 30.756612,
    rating: 2.4,
    reviewCount: 49,
    priceRange: { en: "Budget", ar: "اقتصادي" },
    amenities: [],
    roomTypes: [
      { en: "Single", ar: "مفردة" },
      { en: "Standard Room with Twin Bed", ar: "غرفة قياسية بسريرين" },
      { en: "Superior Twin Room", ar: "غرفة سوبيريور توأم" },
      { en: "Family Room", ar: "غرفة عائلية" }
    ],
    contactInfo: {
      phone: { en: "086/2364021", ar: "086/2364021" },
      email: { en: "mohamed.adel2010.ma@gmail.com", ar: "mohamed.adel2010.ma@gmail.com" },
      website: { en: "http://whitepalacehall.com", ar: "http://whitepalacehall.com" }
    },
    starRating: 2
  },
  {
    id: "16",
    name: { en: "Al Zahraa", ar: "الزهراء" },
    description: { en: "Hotel on Port Said St (Minya), popular category.", ar: "فندق في شارع بورسعيد (المنيا)، فئة شعبية." },
    imageUrl: "/assets/images/hotels/Al Zahraa.jpg",
    imageGallery: ["/assets/images/hotels/Al Zahraa.jpg"],
    latitude: 28.0970,
    longitude: 30.7530,
    rating: 2.0,
    reviewCount: 10,
    priceRange: { en: "Budget", ar: "اقتصادي" },
    amenities: [],
    roomTypes: [],
    contactInfo: {
      phone: { en: "086/2362979", ar: "086/2362979" },
      email: { en: "mohamed.adel2010.ma@gmail.com", ar: "mohamed.adel2010.ma@gmail.com" },
      website: { en: "http://whitepalacehall.com", ar: "http://whitepalacehall.com" }
    },
    starRating: 2
  },
  {
    id: "17",
    name: { en: "Queen Isis Hotel", ar: "فندق الملكة إيزيس" },
    description: { en: "Elegant hotel with traditional Egyptian decor.", ar: "فندق أنيق بديكور مصري تقليدي." },
    imageUrl: "/assets/images/hotels/Isis/isis2.jpg",
    imageGallery: [
      "/assets/images/hotels/Isis/isis2.jpg",
      "/assets/images/hotels/Isis/isis11.png",
      "/assets/images/hotels/Isis/isis8.png",
      "/assets/images/hotels/Isis/isis3.png"
    ],
    latitude: 28.1102,
    longitude: 30.7511,
    rating: 4.1,
    reviewCount: 780,
    priceRange: { en: "48$", ar: "٤٨ دولار" },
    amenities: [
      { en: "Wi-Fi Access", ar: "خدمة واي فاي" },
      { en: "Restaurant", ar: "مطعم" },
      { en: "Breakfast", ar: "إفطار" }
    ],
    roomTypes: [],
    contactInfo: {
      phone: { en: "01009992233", ar: "٠١٠٠٩٩٩٢٢٣٣" },
      email: { en: "info@queenisis.com", ar: "info@queenisis.com" },
      website: { en: "https://www.queenisis.com", ar: "https://www.queenisis.com" }
    },
    starRating: 4
  }
];

const postData = Buffer.from(JSON.stringify(HOTELS), 'utf-8');

const options = {
  hostname: 'localhost',
  port: 7123,
  path: '/api/Hotels/bulk',
  method: 'POST',
  rejectUnauthorized: false,
  headers: {
    'Content-Type': 'application/json; charset=utf-8',
    'Content-Length': postData.length
  }
};

console.log(`Starting bulk insertion for ${HOTELS.length} hotels...`);

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