const https = require('https');

const ITINERARIES = [
  {
    id: '1',
    title: {
      en: 'Ancient Minya Discovery - 3 Days',
      ar: 'اكتشاف المنيا القديمة - 3 أيام'
    },
    description: {
      en: 'Explore the most significant archaeological sites of Minya including Beni Hassan tombs, Tell el-Amarna, and Tuna el-Gebel',
      ar: 'استكشف أهم المواقع الأثرية في المنيا بما في ذلك مقابر بني حسن وتل العمارنة وطونة الجبل'
    },
    duration: {
      en: '3 Days / 2 Nights',
      ar: '3 أيام / ليلتان'
    },
    difficulty: {
      en: 'Moderate',
      ar: 'متوسط'
    },
    price: {
      en: 'From $150 per person',
      ar: 'من 150 دولار للشخص'
    },
    image: '/assets/images/beni_hassan.webp',
    highlights: [
      { en: 'Beni Hassan Tombs', ar: 'مقابر بني حسن' },
      { en: 'Tell el-Amarna', ar: 'تل العمارنة' },
      { en: 'Tuna el-Gebel', ar: 'طونة الجبل' },
      { en: 'Nile River Views', ar: 'إطلالات نهر النيل' }
    ],
    includes: [
      { en: 'Accommodation', ar: 'الإقامة' },
      { en: 'Transportation', ar: 'النقل' },
      { en: 'Guide', ar: 'المرشد' },
      { en: 'Entrance Fees', ar: 'رسوم الدخول' }
    ],
    excludes: [
      { en: 'Meals', ar: 'الوجبات' },
      { en: 'Personal Expenses', ar: 'المصروفات الشخصية' },
      { en: 'Tips', ar: 'البقشيش' }
    ],
    bestTime: {
      en: 'October - April',
      ar: 'أكتوبر - أبريل'
    },
    groupSize: {
      en: '2-15 people',
      ar: '2-15 شخص'
    },
    isFeatured: true,
    category: {
      en: 'Archaeological',
      ar: 'أثري'
    }
  },
  {
    id: '2',
    title: {
      en: 'Nile River Experience - 1 Day',
      ar: 'تجربة نهر النيل - يوم واحد'
    },
    description: {
      en: 'A relaxing day cruise along the Nile with traditional felucca sailing and riverside dining',
      ar: 'رحلة نهارية مريحة على النيل مع الإبحار بالفلوكة التقليدية وتناول الطعام على ضفة النهر'
    },
    duration: {
      en: '1 Day',
      ar: 'يوم واحد'
    },
    difficulty: {
      en: 'Easy',
      ar: 'سهل'
    },
    price: {
      en: 'From $75 per person',
      ar: 'من 75 دولار للشخص'
    },
    image: '/assets/images/nile_boats.jpg',
    highlights: [
      { en: 'Felucca Sailing', ar: 'الإبحار بالفلوكة' },
      { en: 'Nile Views', ar: 'إطلالات النيل' },
      { en: 'Traditional Lunch', ar: 'غداء تقليدي' },
      { en: 'Sunset Cruise', ar: 'رحلة الغروب' }
    ],
    includes: [
      { en: 'Felucca Boat', ar: 'قارب الفلوكة' },
      { en: 'Lunch', ar: 'الغداء' },
      { en: 'Guide', ar: 'المرشد' },
      { en: 'Refreshments', ar: 'المرطبات' }
    ],
    excludes: [
      { en: 'Transportation to/from hotel', ar: 'النقل من وإلى الفندق' },
      { en: 'Personal Expenses', ar: 'المصروفات الشخصية' }
    ],
    bestTime: {
      en: 'Year Round',
      ar: 'على مدار السنة'
    },
    groupSize: {
      en: '2-20 people',
      ar: '2-20 شخص'
    },
    isFeatured: true,
    category: {
      en: 'Nature & River',
      ar: 'طبيعة ونهر'
    }
  },
  {
    id: '3',
    title: {
      en: 'Cultural Heritage Tour - 5 Days',
      ar: 'جولة التراث الثقافي - 5 أيام'
    },
    description: {
      en: 'Comprehensive exploration of Minya\'s cultural heritage including museums, traditional crafts, and local communities',
      ar: 'استكشاف شامل للتراث الثقافي للمنيا بما في ذلك المتاحف والحرف التقليدية والمجتمعات المحلية'
    },
    duration: {
      en: '5 Days / 4 Nights',
      ar: '5 أيام / 4 ليالي'
    },
    difficulty: {
      en: 'Easy',
      ar: 'سهل'
    },
    price: {
      en: 'From $300 per person',
      ar: 'من 300 دولار للشخص'
    },
    image: '/assets/images/pattern_bg.png',
    highlights: [
      { en: 'Museums', ar: 'المتاحف' },
      { en: 'Traditional Crafts', ar: 'الحرف التقليدية' },
      { en: 'Local Markets', ar: 'الأسواق المحلية' },
      { en: 'Cultural Performances', ar: 'العروض الثقافية' }
    ],
    includes: [
      { en: '4-star Accommodation', ar: 'إقامة 4 نجوم' },
      { en: 'All Meals', ar: 'جميع الوجبات' },
      { en: 'Transportation', ar: 'النقل' },
      { en: 'Guide', ar: 'المرشد' },
      { en: 'Activities', ar: 'الأنشطة' }
    ],
    excludes: [
      { en: 'International Flights', ar: 'الطيران الدولي' },
      { en: 'Visa Fees', ar: 'رسوم التأشيرة' },
      { en: 'Personal Shopping', ar: 'التسوق الشخصي' }
    ],
    bestTime: {
      en: 'November - March',
      ar: 'نوفمبر - مارس'
    },
    groupSize: {
      en: '4-12 people',
      ar: '4-12 شخص'
    },
    isFeatured: false,
    category: {
      en: 'Cultural',
      ar: 'ثقافي'
    }
  }
];

const postData = Buffer.from(JSON.stringify(ITINERARIES), 'utf-8');

const options = {
  hostname: 'localhost',
  port: 7123,
  path: '/api/Itineraries/bulk',
  method: 'POST',
  rejectUnauthorized: false,
  headers: {
    'Content-Type': 'application/json; charset=utf-8',
    'Content-Length': postData.length
  }
};

console.log(`Starting bulk insertion for ${ITINERARIES.length} itineraries...`);

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