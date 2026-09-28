const axios = require('axios');
const FormData = require('form-data');

// الرابط المباشر للباك إند
const API_URL = 'https://localhost:7123/api/Hotels';

async function testCreateHotel() {
  const form = new FormData();

  // 1. توليد صور وهمية بصيغة Buffer لاختبار رفع الملفات
  const dummyMainImage = Buffer.from('Fake main image content for testing');
  const dummyGalleryImage1 = Buffer.from('Fake gallery image 1 content');
  const dummyGalleryImage2 = Buffer.from('Fake gallery image 2 content');

  // 2. تعبئة النصوص المترجمة (LocalizedText)
  form.append('Name.Ar', 'فندق حورس السياحي بالمنيا');
  form.append('Name.En', 'Horus Tourist Hotel Minya');

  form.append('Description.Ar', 'فندق مطل على كورنيش النيل بالمنيا، يقدم أفضل الخدمات الفندقية.');
  form.append('Description.En', 'Hotel overlooking the Minya Nile Corniche, offering premium accommodation services.');

  // 3. الأرقام والإحداثيات
  form.append('Latitude', '28.109885');
  form.append('Longitude', '30.750301');
  form.append('Rating', '4.5');
  form.append('ReviewCount', '120');
  form.append('StarRating', '4');

  // 4. نطاق الأسعار
  form.append('PriceRange.Ar', '1500 - 3200 ج.م');
  form.append('PriceRange.En', '$30 - $65');

  // 5. بيانات الاتصال (Nested Object)
  form.append('ContactInfo.Phone.Ar', '0862345678');
  form.append('ContactInfo.Phone.En', '0862345678');
  form.append('ContactInfo.Email.Ar', 'info@horusminyahotel.eg');
  form.append('ContactInfo.Email.En', 'info@horusminyahotel.eg');
  form.append('ContactInfo.Website.Ar', 'https://horus-minya.eg');
  form.append('ContactInfo.Website.En', 'https://horus-minya.eg');

  // 6. قائمة المرافق (Amenities Array)
  const amenities = [
    { ar: 'واي فاي مجاني', en: 'Free Wi-Fi' },
    { ar: 'حمام سباحة خارجي', en: 'Outdoor Pool' },
    { ar: 'إطلالة نيلية', en: 'Nile View' }
  ];

  amenities.forEach((item, index) => {
    form.append(`Amenities[${index}].Ar`, item.ar);
    form.append(`Amenities[${index}].En`, item.en);
  });

  // 7. قائمة أنواع الغرف (RoomTypes Array)
  const roomTypes = [
    { ar: 'غرفة ديلوكس مفردة', en: 'Deluxe Single Room' },
    { ar: 'جناح عائلي مطل على النيل', en: 'Family Suite Nile View' }
  ];

  roomTypes.forEach((item, index) => {
    form.append(`RoomTypes[${index}].Ar`, item.ar);
    form.append(`RoomTypes[${index}].En`, item.en);
  });

  // 8. إرفاق ملف الصورة الرئيسية (IFormFile)
  form.append('ImageFile', dummyMainImage, {
    filename: 'main_facade.jpg',
    contentType: 'image/jpeg'
  });

  // 9. إرفاق ملفات المعرض (List<IFormFile>)
  form.append('ImageGalleryFiles', dummyGalleryImage1, {
    filename: 'lobby_view.jpg',
    contentType: 'image/jpeg'
  });

  form.append('ImageGalleryFiles', dummyGalleryImage2, {
    filename: 'suite_bedroom.jpg',
    contentType: 'image/jpeg'
  });

  console.log('Sending request to:', API_URL);

  try {
    const response = await axios.post(API_URL, form, {
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

testCreateHotel();