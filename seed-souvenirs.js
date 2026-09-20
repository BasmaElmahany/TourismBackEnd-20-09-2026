const https = require('https');

const SOUVENIR_SHOPS = [
  {
    id: 'sv1',
    name: 'Minya Heritage Crafts Center',
    nameAr: 'مركز حرف التراث بالمنيا',
    description: 'Authentic Egyptian handicrafts including alabaster carvings, wooden artifacts, and traditional decorations from local artisans.',
    descriptionAr: 'حرف يدوية مصرية أصيلة تشمل منحوتات المرمر والتحف الخشبية والزينة التقليدية من الحرفيين المحليين.',
    category: 'handicrafts',
    categoryAr: 'حرف يدوية',
    address: 'Corniche El Nile, Downtown Minya',
    addressAr: 'كورنيش النيل، وسط المنيا',
    phone: '+20 86 234 7890',
    email: 'info@minyaheritage.com',
    image: '/assets/images/Handicrafts.jpg',
    images: [
      '/assets/images/souvenirs/heritage-1.jpg',
      '/assets/images/souvenirs/heritage-2.jpg',
      '/assets/images/souvenirs/heritage-3.jpg'
    ],
    latitude: 28.0890,
    longitude: 30.7610,
    distanceKm: 0.5,
    rating: 4.7,
    reviewCount: 156,
    priceRange: '$$',
    openingHours: 'Daily 9:00 AM - 9:00 PM',
    openingHoursAr: 'يومياً من 9 صباحاً - 9 مساءً',
    isFeatured: true,
    acceptsCreditCard: true,
    hasDelivery: true,
    hasOnlineStore: false,
    specialties: [
      'Alabaster Carvings',
      'Wooden Artifacts',
      'Traditional Decorations',
      'Handmade Baskets'
    ],
    specialtiesAr: [
      'منحوتات المرمر',
      'التحف الخشبية',
      'الزينة التقليدية',
      'السلال المصنوعة يدوياً'
    ]
  },
  {
    id: 'sv2',
    name: 'Pharaonic Treasures Shop',
    nameAr: 'محل كنوز فرعونية',
    description: 'Replicas of ancient Egyptian artifacts, statues, and decorative pieces inspired by pharaonic art.',
    descriptionAr: 'نسخ من التحف المصرية القديمة والتماثيل والقطع الزخرفية المستوحاة من الفن الفرعوني.',
    category: 'handicrafts',
    categoryAr: 'حرف يدوية',
    address: 'Saad Zaghloul Street, Near Museum',
    addressAr: 'شارع سعد زغلول، قرب المتحف',
    phone: '+20 86 234 7891',
    email: null,
    image: '/assets/images/Pharaonic Treasures Shop.png',
    images: [],
    latitude: 28.0950,
    longitude: 30.7550,
    distanceKm: 0.8,
    rating: 4.5,
    reviewCount: 98,
    priceRange: '$$',
    openingHours: 'Daily 10:00 AM - 8:00 PM',
    openingHoursAr: 'يومياً من 10 صباحاً - 8 مساءً',
    isFeatured: true,
    acceptsCreditCard: true,
    hasDelivery: false,
    hasOnlineStore: false,
    specialties: [
      'Pharaonic Statues',
      'Scarab Amulets',
      'Cartouche Jewelry',
      'Ancient Replicas'
    ],
    specialtiesAr: [
      'التماثيل الفرعونية',
      'تمائم الجعران',
      'مجوهرات الخرطوش',
      'نسخ أثرية'
    ]
  },
  {
    id: 'sv3',
    name: 'Golden Nile Jewelry',
    nameAr: 'مجوهرات النيل الذهبي',
    description: 'Fine gold and silver jewelry with traditional Egyptian designs, including cartouche pendants and pharaonic motifs.',
    descriptionAr: 'مجوهرات ذهبية وفضية فاخرة بتصاميم مصرية تقليدية، بما في ذلك قلائد الخرطوش والزخارف الفرعونية.',
    category: 'jewelry',
    categoryAr: 'مجوهرات',
    address: 'Al Horreya Street, Gold Market',
    addressAr: 'شارع الحرية، سوق الذهب',
    phone: '+20 86 234 7892',
    email: null,
    image: '/assets/images/Golden Nile Jewelry.jpg',
    images: [],
    latitude: 28.0900,
    longitude: 30.7600,
    distanceKm: 0.6,
    rating: 4.8,
    reviewCount: 203,
    priceRange: '$$$',
    openingHours: 'Sat-Thu 10:00 AM - 10:00 PM, Fri 2:00 PM - 10:00 PM',
    openingHoursAr: 'السبت-الخميس من 10 صباحاً - 10 مساءً، الجمعة من 2 ظهراً - 10 مساءً',
    isFeatured: true,
    acceptsCreditCard: true,
    hasDelivery: false,
    hasOnlineStore: true,
    specialties: [
      'Gold Cartouche',
      'Silver Ankh Pendants',
      'Eye of Horus Jewelry',
      'Custom Name Jewelry'
    ],
    specialtiesAr: [
      'خرطوش ذهبي',
      'قلائد عنخ فضية',
      'مجوهرات عين حورس',
      'مجوهرات بالاسم حسب الطلب'
    ]
  },
  {
    id: 'sv4',
    name: 'Cleopatra Accessories',
    nameAr: 'إكسسوارات كليوباترا',
    description: 'Handmade accessories, beaded jewelry, and traditional Egyptian ornaments for men and women.',
    descriptionAr: 'إكسسوارات مصنوعة يدوياً ومجوهرات مطرزة بالخرز وزينة مصرية تقليدية للرجال والنساء.',
    category: 'jewelry',
    categoryAr: 'مجوهرات',
    address: 'Port Said Street, Downtown',
    addressAr: 'شارع بورسعيد، وسط البلد',
    phone: '+20 86 234 7893',
    email: null,
    image: '/assets/images/Cleopatra Accessories.png',
    images: [],
    latitude: 28.0920,
    longitude: 30.7580,
    distanceKm: 0.9,
    rating: 4.4,
    reviewCount: 87,
    priceRange: '$',
    openingHours: 'Daily 9:00 AM - 9:00 PM',
    openingHoursAr: 'يومياً من 9 صباحاً - 9 مساءً',
    isFeatured: false,
    acceptsCreditCard: false,
    hasDelivery: false,
    hasOnlineStore: false,
    specialties: [
      'Beaded Bracelets',
      'Leather Accessories',
      'Traditional Necklaces',
      'Hair Ornaments'
    ],
    specialtiesAr: [
      'أساور مطرزة بالخرز',
      'إكسسوارات جلدية',
      'قلائد تقليدية',
      'زينة الشعر'
    ]
  },
  {
    id: 'sv5',
    name: 'Egyptian Cotton House',
    nameAr: 'بيت القطن المصري',
    description: 'Premium Egyptian cotton products including scarves, shawls, traditional galabeyas, and embroidered textiles.',
    descriptionAr: 'منتجات القطن المصري الفاخر بما في ذلك الأوشحة والشالات والجلابيات التقليدية والمنسوجات المطرزة.',
    category: 'textiles',
    categoryAr: 'منسوجات',
    address: 'Tahrir Street, Textile Market',
    addressAr: 'شارع التحرير، سوق المنسوجات',
    phone: '+20 86 234 7894',
    email: null,
    image: '/assets/images/Egyptian Cotton House.png',
    images: [],
    latitude: 28.0910,
    longitude: 30.7590,
    distanceKm: 0.7,
    rating: 4.6,
    reviewCount: 142,
    priceRange: '$$',
    openingHours: 'Daily 9:00 AM - 8:00 PM',
    openingHoursAr: 'يومياً من 9 صباحاً - 8 مساءً',
    isFeatured: true,
    acceptsCreditCard: true,
    hasDelivery: true,
    hasOnlineStore: true,
    specialties: [
      'Egyptian Cotton Scarves',
      'Traditional Galabeyas',
      'Embroidered Shawls',
      'Table Linens'
    ],
    specialtiesAr: [
      'أوشحة قطن مصري',
      'جلابيات تقليدية',
      'شالات مطرزة',
      'مفارش طاولة'
    ]
  },
  {
    id: 'sv6',
    name: 'Bedouin Textiles & Carpets',
    nameAr: 'منسوجات وسجاد بدوي',
    description: 'Authentic Bedouin textiles, handwoven carpets, cushions, and traditional wall hangings.',
    descriptionAr: 'منسوجات بدوية أصيلة وسجاد منسوج يدوياً ووسائد وتعليقات جدارية تقليدية.',
    category: 'textiles',
    categoryAr: 'منسوجات',
    address: 'El Gomhoreya Street, Handicraft Center',
    addressAr: 'شارع الجمهورية، مركز الحرف اليدوية',
    phone: '+20 86 234 7895',
    email: null,
    image: '/assets/images/Bedouin Textiles & Carpets.png',
    images: [],
    latitude: 28.0930,
    longitude: 30.7570,
    distanceKm: 1.2,
    rating: 4.5,
    reviewCount: 76,
    priceRange: '$$',
    openingHours: 'Sat-Thu 10:00 AM - 7:00 PM',
    openingHoursAr: 'السبت-الخميس من 10 صباحاً - 7 مساءً',
    isFeatured: false,
    acceptsCreditCard: true,
    hasDelivery: true,
    hasOnlineStore: false,
    specialties: [
      'Handwoven Carpets',
      'Bedouin Cushions',
      'Wall Hangings',
      'Traditional Bags'
    ],
    specialtiesAr: [
      'سجاد منسوج يدوياً',
      'وسائد بدوية',
      'تعليقات جدارية',
      'حقائب تقليدية'
    ]
  },
  {
    id: 'sv7',
    name: 'Nile Valley Pottery',
    nameAr: 'فخار وادي النيل',
    description: 'Traditional Egyptian pottery, ceramic plates, vases, and decorative pieces made by local artisans.',
    descriptionAr: 'الفخار المصري التقليدي والأطباق الخزفية والمزهريات والقطع الزخرفية من صنع الحرفيين المحليين.',
    category: 'pottery',
    categoryAr: 'فخار',
    address: 'Corniche Road, Near Pottery Workshop',
    addressAr: 'طريق الكورنيش، قرب ورشة الفخار',
    phone: '+20 86 234 7896',
    email: null,
    image: '/assets/images/فخار وادي النيل.jpg',
    images: [],
    latitude: 28.0880,
    longitude: 30.7620,
    distanceKm: 1.0,
    rating: 4.3,
    reviewCount: 64,
    priceRange: '$',
    openingHours: 'Daily 8:00 AM - 6:00 PM',
    openingHoursAr: 'يومياً من 8 صباحاً - 6 مساءً',
    isFeatured: false,
    acceptsCreditCard: false,
    hasDelivery: false,
    hasOnlineStore: false,
    specialties: [
      'Handmade Pottery',
      'Ceramic Plates',
      'Decorative Vases',
      'Traditional Jars'
    ],
    specialtiesAr: [
      'فخار مصنوع يدوياً',
      'أطباق خزفية',
      'مزهريات زخرفية',
      'جرار تقليدية'
    ]
  },
  {
    id: 'sv8',
    name: 'Minya Papyrus Gallery',
    nameAr: 'معرض بردي المنيا',
    description: 'Authentic papyrus paintings featuring pharaonic scenes, hieroglyphics, and traditional Egyptian art.',
    descriptionAr: 'لوحات بردي أصلية تضم مشاهد فرعونية وهيروغليفية وفن مصري تقليدي.',
    category: 'papyrus',
    categoryAr: 'بردي',
    address: 'Museum Street, Cultural Center',
    addressAr: 'شارع المتحف، المركز الثقافي',
    phone: '+20 86 234 7897',
    email: 'info@minyapapyrus.com',
    image: '/assets/images/معرض بردي المنيا.jpg',
    images: [],
    latitude: 28.0960,
    longitude: 30.7540,
    distanceKm: 1.3,
    rating: 4.7,
    reviewCount: 118,
    priceRange: '$$',
    openingHours: 'Daily 9:00 AM - 7:00 PM',
    openingHoursAr: 'يومياً من 9 صباحاً - 7 مساءً',
    isFeatured: true,
    acceptsCreditCard: true,
    hasDelivery: true,
    hasOnlineStore: true,
    specialties: [
      'Papyrus Paintings',
      'Hieroglyphic Art',
      'Custom Cartouche',
      'Pharaonic Scenes'
    ],
    specialtiesAr: [
      'لوحات بردي',
      'فن هيروغليفي',
      'خرطوش حسب الطلب',
      'مشاهد فرعونية'
    ]
  },
  {
    id: 'sv9',
    name: 'Egyptian Art Studio',
    nameAr: 'استوديو الفن المصري',
    description: 'Contemporary and traditional Egyptian artwork, paintings, and handcrafted decorative pieces.',
    descriptionAr: 'أعمال فنية مصرية معاصرة وتقليدية ولوحات وقطع زخرفية مصنوعة يدوياً.',
    category: 'gallery',
    categoryAr: 'معرض فني',
    address: 'Al Horreya Street, Art District',
    addressAr: 'شارع الحرية، حي الفنون',
    phone: '+20 86 234 7898',
    email: 'contact@egyptianartstudio.com',
    image: '/assets/images/استوديو الفن المصري.jpg',
    images: [],
    latitude: 28.0895,
    longitude: 30.7605,
    distanceKm: 0.8,
    rating: 4.6,
    reviewCount: 92,
    priceRange: '$$$',
    openingHours: 'Sat-Thu 10:00 AM - 8:00 PM',
    openingHoursAr: 'السبت-الخميس من 10 صباحاً - 8 مساءً',
    isFeatured: true,
    acceptsCreditCard: true,
    hasDelivery: true,
    hasOnlineStore: true,
    specialties: [
      'Oil Paintings',
      'Watercolor Art',
      'Mixed Media',
      'Sculptures'
    ],
    specialtiesAr: [
      'لوحات زيتية',
      'فن الألوان المائية',
      'وسائط مختلطة',
      'منحوتات'
    ]
  },
  {
    id: 'sv10',
    name: 'Minya Souq (Traditional Market)',
    nameAr: 'سوق المنيا التقليدي',
    description: 'Large traditional market offering a wide variety of souvenirs, handicrafts, spices, and local products.',
    descriptionAr: 'سوق تقليدي كبير يقدم مجموعة واسعة من الهدايا التذكارية والحرف اليدوية والتوابل والمنتجات المحلية.',
    category: 'market',
    categoryAr: 'سوق تقليدي',
    address: 'Downtown Minya, Central Market Area',
    addressAr: 'وسط المنيا، منطقة السوق المركزي',
    phone: '+20 86 234 7899',
    email: null,
    image: '/assets/images/سوق المنيا التقليدي.jpg',
    images: [],
    latitude: 28.0905,
    longitude: 30.7595,
    distanceKm: 0.4,
    rating: 4.4,
    reviewCount: 245,
    priceRange: '$',
    openingHours: 'Daily 8:00 AM - 10:00 PM',
    openingHoursAr: 'يومياً من 8 صباحاً - 10 مساءً',
    isFeatured: true,
    acceptsCreditCard: false,
    hasDelivery: false,
    hasOnlineStore: false,
    specialties: [
      'Various Souvenirs',
      'Local Handicrafts',
      'Spices & Herbs',
      'Traditional Clothing'
    ],
    specialtiesAr: [
      'هدايا تذكارية متنوعة',
      'حرف يدوية محلية',
      'توابل وأعشاب',
      'ملابس تقليدية'
    ]
  },
  {
    id: 'sv11',
    name: 'Nile Bazaar',
    nameAr: 'بازار النيل',
    description: 'Tourist-friendly bazaar with curated selection of quality Egyptian souvenirs and gifts.',
    descriptionAr: 'بازار صديق للسياح مع مجموعة منتقاة من الهدايا التذكارية المصرية عالية الجودة.',
    category: 'market',
    categoryAr: 'سوق',
    address: 'Corniche El Nile, Tourist Area',
    addressAr: 'كورنيش النيل، المنطقة السياحية',
    phone: '+20 86 234 7800',
    email: null,
    image: '/assets/images/بازار النيل.jpg',
    images: [],
    latitude: 28.0875,
    longitude: 30.7625,
    distanceKm: 1.1,
    rating: 4.5,
    reviewCount: 167,
    priceRange: '$$',
    openingHours: 'Daily 9:00 AM - 11:00 PM',
    openingHoursAr: 'يومياً من 9 صباحاً - 11 مساءً',
    isFeatured: true,
    acceptsCreditCard: true,
    hasDelivery: false,
    hasOnlineStore: false,
    specialties: [
      'Curated Souvenirs',
      'Gift Sets',
      'Packaged Products',
      'Tourist Essentials'
    ],
    specialtiesAr: [
      'هدايا تذكارية منتقاة',
      'مجموعات هدايا',
      'منتجات معبأة',
      'أساسيات السياح'
    ]
  },
  {
    id: 'sv12',
    name: 'Alabaster Workshop & Shop',
    nameAr: 'ورشة ومحل المرمر',
    description: 'Specialized in alabaster products with on-site workshop where you can watch artisans at work.',
    descriptionAr: 'متخصص في منتجات المرمر مع ورشة عمل في الموقع حيث يمكنك مشاهدة الحرفيين أثناء العمل.',
    category: 'handicrafts',
    categoryAr: 'حرف يدوية',
    address: 'Industrial Area, East Minya',
    addressAr: 'المنطقة الصناعية، شرق المنيا',
    phone: '+20 86 234 7801',
    email: null,
    image: '/assets/images/Alabaster Workshop & Shop.jpg',
    images: [],
    latitude: 28.0850,
    longitude: 30.7700,
    distanceKm: 2.5,
    rating: 4.8,
    reviewCount: 134,
    priceRange: '$$',
    openingHours: 'Sat-Thu 8:00 AM - 5:00 PM',
    openingHoursAr: 'السبت-الخميس من 8 صباحاً - 5 مساءً',
    isFeatured: true,
    acceptsCreditCard: true,
    hasDelivery: true,
    hasOnlineStore: false,
    specialties: [
      'Alabaster Statues',
      'Decorative Vases',
      'Custom Carvings',
      'Workshop Tours'
    ],
    specialtiesAr: [
      'تماثيل مرمر',
      'مزهريات زخرفية',
      'نقوش حسب الطلب',
      'جولات الورشة'
    ]
  }
];

const postData = Buffer.from(JSON.stringify(SOUVENIR_SHOPS), 'utf-8');

const options = {
  hostname: 'localhost',
  port: 7123,
  path: '/api/Souvenirs/shops/bulk',
  method: 'POST',
  rejectUnauthorized: false,
  headers: {
    'Content-Type': 'application/json; charset=utf-8',
    'Content-Length': postData.length
  }
};

console.log(`Starting bulk insertion for ${SOUVENIR_SHOPS.length} souvenir shops...`);

const req = https.request(options, (res) => {
  let responseBody = '';
  res.setEncoding('utf8');
  res.on('data', (chunk) => (responseBody += chunk));
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