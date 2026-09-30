const fs = require('fs');
const path = require('path');
const axios = require('axios');
const FormData = require('form-data');
const https = require('https');

// إنشاء صور وهمية للاختبار
const mainImagePath = path.join(__dirname, 'dummy-main.jpg');
const gallery1Path = path.join(__dirname, 'dummy-gallery-1.jpg');
const gallery2Path = path.join(__dirname, 'dummy-gallery-2.jpg');

fs.writeFileSync(mainImagePath, 'Fake main image');
fs.writeFileSync(gallery1Path, 'Fake gallery image 1');
fs.writeFileSync(gallery2Path, 'Fake gallery image 2');

async function testCreateHotelWithImages() {
    const form = new FormData();

    // 1. الاسم (إجباري)
    form.append('Name.Ar', 'فندق تجريبي بالصور');
    form.append('Name.En', 'Test Hotel With Images');

    // 2. الصورة الرئيسية (ملف)
    form.append('ImageFile', fs.createReadStream(mainImagePath));

    // 3. صور المعرض (ملفات متعددة بنفس الاسم ImageGalleryFiles)
    form.append('ImageGalleryFiles', fs.createReadStream(gallery1Path));
    form.append('ImageGalleryFiles', fs.createReadStream(gallery2Path));

    const agent = new https.Agent({
        rejectUnauthorized: false
    });

    try {
        console.log('--- إرسال الاسم + الصورة الرئيسية + صور المعرض ---');
        const apiUrl = 'https://localhost:7123/api/Hotels';

        const response = await axios.post(apiUrl, form, {
            headers: {
                ...form.getHeaders()
            },
            httpsAgent: agent
        });

        console.log('\n✅ نجحت العملية!');
        console.log('Status Code:', response.status);
        console.log('Response Data:', JSON.stringify(response.data, null, 2));

    } catch (error) {
        console.log('\n❌ فشل الطلب!');
        if (error.response) {
            console.log('HTTP Status:', error.response.status);
            console.log('Response Body:', JSON.stringify(error.response.data, null, 2));
        } else {
            console.error('Error:', error.message);
        }
    } finally {
        // حذف الملفات المؤقتة
        [mainImagePath, gallery1Path, gallery2Path].forEach(file => {
            if (fs.existsSync(file)) fs.unlinkSync(file);
        });
    }
}

testCreateHotelWithImages();