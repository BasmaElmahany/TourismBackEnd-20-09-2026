const axios = require('axios');
const FormData = require('form-data');
const https = require('https');

// 1. ضعي هنا معرّف الفندق الفعلي الموجود لديك في قاعدة البيانات
const HOTEL_ID = '224c6d98-f737-44c4-bc4a-c7b0d87696a2';

// رابط الـ API (يمكنك استخدام localhost أو السيرفر المباشر)
const BASE_URL = 'https://localhost:7123/api/Hotels';
const API_URL = `${BASE_URL}/${HOTEL_ID}`;

// تجاوز فحص الشهادة المحلية الموقعة ذاتياً
const httpsAgent = new https.Agent({
  rejectUnauthorized: false
});

async function testUpdateHotel() {
  if (!HOTEL_ID || HOTEL_ID.includes('ضع_هنا')) {
    console.error('❌ يرجى تعيين قيمة HOTEL_ID بمعرف فندق صحيح أولاً.');
    return;
  }

  const form = new FormData();

  // 1. المعرف (مطابق للمسار)
  form.append('Id', HOTEL_ID);

  // 2. النصوص المترجمة (الاسم والوصف)
  form.append('Name.Ar', 'فندق حورس السياحي بالمنيا (تم التحديث)');
  form.append('Name.En', 'Horus Tourist Hotel Minya (Updated)');

  form.append('Description.Ar', 'تم تحديث البيانات وإضافة مرافق جديدة وإطلالة نيلية مطورة.');
  form.append('Description.En', 'Information updated with newly added facilities and enhanced Nile view.');

  // 3. الأرقام والإحداثيات
  form.append('Latitude', '28.115000');
  form.append('Longitude', '30.755000');
  form.append('Rating', '4.8');
  form.append('ReviewCount', '150');
  form.append('StarRating', '5');

  // 4. نطاق الأسعار
  form.append('PriceRange.Ar', '2000 - 4500 ج.م');
  form.append('PriceRange.En', '$45 - $90');

  // 5. بيانات الاتصال
  form.append('ContactInfo.Phone.Ar', '0862399999');
  form.append('ContactInfo.Phone.En', '0862399999');
  form.append('ContactInfo.Email.Ar', 'update@horusminya.eg');
  form.append('ContactInfo.Email.En', 'update@horusminya.eg');
  form.append('ContactInfo.Website.Ar', 'https://horus-minya.eg/updated');
  form.append('ContactInfo.Website.En', 'https://horus-minya.eg/updated');

  // 6. صورة الواجهة الرئيسية الجديدة (اختياري: اختبري رفع ملف أو الإبقاء على رابط سابق)
  const dummyMainImage = Buffer.from('Updated main image binary content');
  form.append('ImageFile', dummyMainImage, {
    filename: 'updated_main_facade.jpg',
    contentType: 'image/jpeg'
  });
  // إذا لم ترغبي برفع صورة جديدة وتريدين الاحتفاظ بالقديمة، أزيلي ImageFile وفعّلي السطر التالي:
  // form.append('ExistingImageUrl', '/assets/images/hotels/existing_image.jpg');

  // 7. صور المعرض الحالية المحتفظ بها (ExistingGalleryUrls)
  // أي رابط غير موجود في هذه القائمة سيقوم الـ Handler بحذفه تلقائياً من السيرفر
  const existingGallery = [
    '/assets/images/hotels/sample_keep_1.jpg'
  ];
  existingGallery.forEach((url, index) => {
    form.append(`ExistingGalleryUrls[${index}]`, url);
  });

  // 8. صور جديدة لإضافتها إلى المعرض (NewImageGalleryFiles)
  const dummyGalleryImage = Buffer.from('New extra gallery image content');
  form.append('NewImageGalleryFiles', dummyGalleryImage, {
    filename: 'new_conference_room.jpg',
    contentType: 'image/jpeg'
  });

  // 9. المرافق والخدمات (Amenities)
  const updatedAmenities = [
    { ar: 'إنترنت فائق السرعة', en: 'High-speed Wi-Fi' },
    { ar: 'نادي صحي وسبا', en: 'Spa & Wellness Center' },
    { ar: 'موقف سيارات مجاني', en: 'Free Parking' }
  ];
  updatedAmenities.forEach((item, index) => {
    form.append(`Amenities[${index}].Ar`, item.ar);
    form.append(`Amenities[${index}].En`, item.en);
  });

  // 10. أنواع الغرف (RoomTypes)
  const updatedRoomTypes = [
    { ar: 'غرفة سوبيريور مفردة', en: 'Superior Single Room' },
    { ar: 'جناح رئاسي مطل على النيل', en: 'Presidential Nile Suite' }
  ];
  updatedRoomTypes.forEach((item, index) => {
    form.append(`RoomTypes[${index}].Ar`, item.ar);
    form.append(`RoomTypes[${index}].En`, item.en);
  });

  console.log(`Sending PUT request to: ${API_URL}`);

  try {
    const response = await axios.put(API_URL, form, {
      httpsAgent,
      headers: {
        ...form.getHeaders()
      }
    });

    console.log('\n Status Code:', response.status);
    console.log(' Response Body:');
    console.dir(response.data, { depth: null, colors: true });

  } catch (error) {
    if (error.response) {
      console.error('\n Server Error Response:', error.response.status);
      console.dir(error.response.data, { depth: null, colors: true });
    } else {
      console.error('\n Network or Connection Error:', error.message);
    }
  }
}

testUpdateHotel();