import { BlogPost } from "../models/tourism.models";


export const blogPosts: BlogPost[] = [
 {
  id: '1',
  title: { 
    en: 'Discovering the Hidden Treasures of Beni Hasan', 
    ar: 'اكتشاف الكنوز المخفية في بني حسن' 
  },
  content: { 
    en: `The Beni Hasan necropolis is one of Egypt’s most extraordinary archaeological sites, located about 20 km south of Minya, on the eastern bank of the Nile. It comprises 39 rock-cut tombs primarily from the 11th and 12th Dynasties of the Middle Kingdom (c. 2055-1795 BC), built for the nomarchs (provincial rulers) of the 16th Upper Egyptian Oryx Nome. Some tombs are exquisitely decorated with vivid wall paintings showing daily life, agriculture, crafts, religious rituals, hunting, war scenes, games, and scenes of foreigners. The lower cemetery contains hundreds of shaft tombs from earlier and later periods, including the First Intermediate Period, late Old Kingdom, and even some from Ptolemaic/Roman eras. Thanks to restoration efforts, many of the paintings have been cleaned and can still display brilliant colors.`, 
    ar: `مقبرة بني حسن هي من أكثر المواقع الأثرية روعة في مصر، وتقع على بُعد حوالي 20 كيلومترًا جنوب المنيا، على الضفة الشرقية للنيل. تتضمن 39 مقبرة محفورة في الصخر من الأساس، تعود في الأساس إلى الأسرة الحادية عشرة والثانية عشرة من الدولة الوسطى (حوالي 2055-1795 قبل الميلاد)، بُنيت لحكام المقاطعة (النومارخ) من المقاطعة السادسة عشر العليا بالاسم Oryx. بعض هذه المقابر مزخرفة بدقة فائقة برسوم جدارية حيوية تُظهر الحياة اليومية، والزراعة، والحرف، والطقوس الدينية، والصيد، ومشاهد الحرب، والألعاب، ومشاهد للغرباء. المقبرة السفلية تحوي مئات المقابر ذات الأعمدة (shaft tombs) من فترات أقدم ولاحقًا، بما في ذلك العصر الوسيط الأول، أواخر الدولة القديمة، وحتى بعض من الفترات البطلمية والرومانية. بفضل جهود الترميم، تم تنظيف العديد من اللوحات ولا تزال تعرض ألوانًا زاهية.` 
  },
  excerpt: { 
    en: 'Explore Beni Hasan’s rock-cut tombs: ancient artworks, vivid storytelling in wall paintings, and burial sites of powerful Middle Kingdom rulers.', 
    ar: 'استكشف مقابر بني حسن المحفورة في الصخر: فنون قديمة، سرد حي باللوحات الجدارية، ومواقع دفن حكّام الدولة الوسطى الأقوياء.' 
  },
  imageUrl: 'assets/images/Discovering the Hidden Treasures of Beni Hasan.png',  // افتراضي أو تختاري صورة من موقعك
  author: { 
    en: 'Dr. Sarah Ahmed', 
    ar: 'الدكتورة سارة أحمد' 
  },
  publishDate: new Date('2024-09-15'),  // ممكن تغيّري التاريخ
  category: { 
    en: 'Attractions', 
    ar: 'المعالم السياحية' 
  },
  tags: [
    [
      { en: 'Beni Hasan', ar: 'بني حسن' },
      { en: 'Middle Kingdom', ar: 'الدولة الوسطى' },
      { en: 'Tombs', ar: 'المقابر' },
      { en: 'Oryx Nome', ar: 'مقاطعة الأوركس' },
      { en: 'Wall Paintings', ar: 'رسوم جدارية' },
      { en: 'Ancient Egypt', ar: 'مصر القديمة' }
    ]
  ],
  readTime: 8,
  featured: true
}
,
  {
  id: '2',
  title: { 
    en: 'A Culinary Journey Through Minya', 
    ar: 'رحلة طهي عبر المنيا' 
  },
  content: { 
    en: `Minya's cuisine reflects the rich agricultural heritage of Upper Egypt and the fertile Nile valley. Local dishes combine simple, hearty ingredients — legumes, rice, vegetables, and slow-cooked meats — seasoned with garlic, coriander, and local ghee or olive oil. Visitors will find popular Egyptian staples such as ful medames (stewed fava beans), koshari (rice, lentils and pasta mix), molokhiya (jute leaf stew), and mahshi (stuffed vegetables), alongside Upper-Egypt specialties like okra "wika" preparations and regional variations of kebab and kofta. Street food and family-run restaurants in Minya serve authentic home-style meals, while local cafés offer traditional breakfast with ful and ta'ameya. The region’s cuisine is strengthened by local produce — dates, legumes, and vegetables from nearby farms — giving Minya a distinct, hearty flavor profile that’s both affordable and richly cultural.`,
    ar: `يعكس مطبخ المنيا التراث الزراعي الغني لصعيد مصر ووادي النيل الخصيب. تتسم الأطباق المحلية بالبساطة والغنى في نفس الوقت — بقوليات، أرز، خضار، ولحوم مطبوخة ببطء — مع توابل بسيطة مثل ثوم، كسبرة، والسمن أو زيت الزيتون المحلي. ستجد في المنيا أطباقًا مصرية معروفة مثل الفول المدَمَّس، الكشري، الملوخية، والمحشي، بالإضافة إلى أطباق صعيدية مميزة مثل طبق البامية (ويكا) وأنواع الكباب والكفتة المحلية. تقدم الباعة الجائلون والمطاعم العائلية وجبات منزلية أصيلة، بينما توفر المقاهي وجبة إفطار تقليدية تعتمد على الفول والطعمية. يقوّي الإنتاج المحلي — مثل التمر والبقوليات والخضروات — نكهة المطبخ في المنيا، مما يجعله مكانًا رائعًا لتجربة أطباق صادقة وبسيطة ومشبعة.` 
  },
  excerpt: { 
    en: 'Discover the authentic flavors of Upper Egyptian cuisine — from ful and koshari to molokhiya and regional okra specialties — and where to taste them in Minya.', 
    ar: 'اكتشف النكهات الأصيلة لمطبخ الصعيد — من الفول والكشري إلى الملوخية وأطباق البامية المحلية — وأين تذوقها في المنيا.' 
  },
  imageUrl: 'assets/images/A Culinary Journey Through Minya.png',
  author: { 
    en: 'Chef Mohamed Hassan', 
    ar: 'الشيف محمد حسن' 
  },
  publishDate: new Date('2024-09-10'),
  category: { 
    en: 'Food & Cuisine', 
    ar: 'الطعام والمأكولات' 
  },
  tags: [
    [
      { en: 'Minya', ar: 'المنيا' },
      { en: 'Upper Egypt', ar: 'صعيد مصر' },
      { en: 'Egyptian Cuisine', ar: 'المطبخ المصري' },
      { en: 'Ful Medames', ar: 'الفول المدَمَّس' },
      { en: 'Koshari', ar: 'الكشري' },
      { en: 'Molokhiya', ar: 'الملوخية' }
    ]
  ],
  readTime: 6,
  featured: false
},
{
  id: '4',
  title: { 
    en: 'The Mysteries of Tell el-Amarna',
    ar: 'أسرار تل العمارنة'
  },
  content: {
    en: `Tell el-Amarna (ancient Akhetaten) was the short-lived royal city founded by Pharaoh Akhenaten in the mid-14th century BCE as the new center for his revolutionary worship of the sun disk Aten. The city’s remains — palaces, temples (including the Great Temple of the Aten), administrative buildings and the distinctive Royal Road — reveal a planned capital created quickly to house the royal household and court. Amarna is especially famous for its unique artistic style (Amarna art), which introduced more naturalistic and intimate representations of the royal family and daily life than earlier Egyptian art.

The site also yielded the Amarna Letters — a cache of cuneiform diplomatic tablets that document international correspondence of the period — and a series of rock-cut tombs for nobles and officials decorated with scenes that illustrate the city’s politics, religion and everyday activities. The Royal Wadi and the Royal Tomb were intended for members of the royal family, while the Tombs of the Nobles contain richly carved and painted reliefs reflecting the period’s iconography and ideology. Today Tell el-Amarna is a key archaeological site in Middle Egypt (near modern Minya) for understanding the Amarna Period’s religious, political and artistic experiments.`,
    ar: `تل العمارنة (أختاتون القديمة) هي المدينة الملكية قصيرة العمر التي أسّسها الفرعون إخناتون في منتصف القرن الرابع عشر قبل الميلاد لتصبح مركز عبادته الثوري لإله الشمس "آتن". تكشف بقايا المدينة — من قصور ومعابد (بما في ذلك المعبد العظيم لآتن)، ومبانٍ إدارية والطريق الملكي — عن عاصمة مخططة أُنشئت بسرعة لإيواء الأسرة المالكة والديوان. تشتهر العمارنة بأسلوبها الفني المميّز (فن العمارنة) الذي قدّم تصويرات أكثر طبيعية وحميمية للعائلة المالكة والحياة اليومية مقارنةً بالفترات السابقة من الفن المصري.

أدّى الموقع إلى اكتشاف رسالة العمارنة — مجموعة رقيمات طينية مكتوبة بالخط المسماري تُظهر المراسلات الدبلوماسية لتلك الحقبة — وسلسلة من المقابر المنحوتة في الصخر لأعيان وموظفي الدولة مزينة بمشاهد توضح السياسة والدين والنشاطات اليومية. وادي الملوك (Royal Wadi) والمقبرة الملكية كانت مخصصة لأفراد العائلة المالكة، بينما تضم مقابر الأعيان نقوشًا ولوحات تعكس أيقونات وفكر تلك الفترة. اليوم يُعدّ تل العمارنة موقعًا أثريًا محوريًا في صعيد مصر (قرب المنيا الحديثة) لفهم تجارب العصر العمارني الدينية والسياسية والفنية.`
  },
  excerpt: {
    en: 'Uncover Akhenaten’s short-lived capital, its revolutionary art, the Amarna letters, and the tombs that tell a story of religion and power.',
    ar: 'اكشف عن العاصمة القصيرة العمر لإخناتون، فن العمارنة الثوري، رسائل العمارنة، والمقابر التي تروي قصة الدين والسلطة.'
  },
  imageUrl: 'assets/images/The Mysteries of Tell el-Amarna (1).png',
  author: {
    en: 'Dr. Amina El-Gohary',
    ar: 'الدكتورة أمينة الجوهرى'
  },
  publishDate: new Date('2024-08-20'),
  category: {
    en: 'Attractions',
    ar: 'المعالم السياحية'
  },
  tags: [
    [
      { en: 'Tell el-Amarna', ar: 'تل العمارنة' },
      { en: 'Akhetaten', ar: 'أختاتون' },
      { en: 'Amarna Period', ar: 'العصر العمارني' },
      { en: 'Amarna Letters', ar: 'رسائل العمارنة' },
      { en: 'Amarna Art', ar: 'فن العمارنة' },
      { en: 'Akhenaten', ar: 'إخناتون' }
    ]
  ],
  readTime: 9,
  featured: false
}
,
{
  id: '5',
  title: { 
    en: 'Tuna el-Gebel: City of the Dead',
    ar: 'تونة الجبل: مدينة الموتى'
  },
  content: {
    en: `Tuna el-Gebel, located west of modern Minya, served as the necropolis of Hermopolis (ancient Khmun) and offers one of the most intriguing glimpses into Egypt’s religious and funerary practices from the Late Period to the Greco-Roman era. The site is best known for its vast network of catacombs used for the burial of sacred animals, especially the ibises and baboons associated with the god Thoth — the deity of wisdom and writing worshiped in Hermopolis.

Among the most remarkable structures at Tuna el-Gebel is the Tomb of Petosiris, a unique blend of traditional Egyptian and Hellenistic art styles that reflects the cultural fusion of the period. Other significant discoveries include the Roman-period houses, mummy portraits, and the sarcophagus of Isidora — a young woman honored with a touching Greek inscription. 

Tuna el-Gebel represents the transition between ancient Egyptian traditions and the new influences that came with Greek and Roman rule, making it an invaluable site for understanding Egypt’s multicultural history.`,
    ar: `تقع تونة الجبل غرب مدينة المنيا الحديثة، وكانت بمثابة جبانة هرموبوليس (خمن القديمة)، وتُعد من أكثر المواقع الأثرية إثارة للاهتمام لفهم الطقوس الدينية والجنائزية في مصر من العصر المتأخر حتى العهدين اليوناني والروماني. يشتهر الموقع بشبكته الواسعة من السراديب التي كانت مخصصة لدفن الحيوانات المقدسة، خاصة طيور أبو منجل والقرود المقدسة المرتبطة بالإله تحوت — إله الحكمة والكتابة الذي كان يُعبد في هرموبوليس.

من أبرز معالم تونة الجبل مقبرة بيتوزيريس، التي تُعد مزيجًا فنيًا رائعًا بين الأسلوبين المصري التقليدي والهيلينستي، وتعكس تداخل الثقافات في تلك الفترة. كما تم العثور على منازل من العصر الروماني، وصور مومياوات، وتابوت إيزيدورا — وهي فتاة شابة خُلّدت بنقش يوناني مؤثر.

تُجسّد تونة الجبل مرحلة انتقالية بين التقاليد المصرية القديمة والتأثيرات الجديدة التي صاحبت الحكمين اليوناني والروماني، مما يجعلها موقعًا لا يُقدّر بثمن لفهم التاريخ المتعدد الثقافات لمصر.`
  },
  excerpt: {
    en: 'Explore Tuna el-Gebel, the necropolis of Hermopolis — where sacred animals, Greco-Roman tombs, and ancient artistry meet in a city for the dead.',
    ar: 'استكشف تونة الجبل، جبانة هرموبوليس — حيث تجتمع الحيوانات المقدسة والمقابر اليونانية الرومانية والفن المصري القديم في مدينة الموتى.'
  },
  imageUrl: 'assets/images/Tuna el-Gebel.jpg',
  author: {
    en: 'Dr. Karim Nabil',
    ar: 'الدكتور كريم نبيل'
  },
  publishDate: new Date('2024-08-10'),
  category: {
    en: 'Attractions',
    ar: 'المعالم السياحية'
  },
  tags: [
    [
      { en: 'Tuna el-Gebel', ar: 'تونة الجبل' },
      { en: 'Hermopolis', ar: 'هرموبوليس' },
      { en: 'Petosiris Tomb', ar: 'مقبرة بيتوزيريس' },
      { en: 'Thoth', ar: 'تحوت' },
      { en: 'Greco-Roman Egypt', ar: 'مصر اليونانية الرومانية' }
    ]
  ],
  readTime: 8,
  featured: false
},
{
  id: '6',
  title: { 
    en: 'Coptic Heritage of Minya',
    ar: 'التراث القبطي في المنيا'
  },
  content: {
    en: `Minya is one of Egypt’s most significant centers of Coptic Christianity, preserving a remarkable spiritual and architectural legacy that dates back to the earliest centuries of the faith. The governorate is home to some of Egypt’s most revered monasteries, churches, and pilgrimage sites, many of which continue to attract visitors and worshippers from around the world.

Among the most notable landmarks is the Monastery of the Virgin Mary at Gabal al-Tayr (the Mountain of the Birds), a sacred site believed to have been visited by the Holy Family during their journey through Egypt. Carved into the limestone cliffs overlooking the Nile, the monastery offers breathtaking views and deep spiritual symbolism. Other important Coptic sites in Minya include the Church of the Virgin in Al-Ashmunein (Hermopolis), the Monastery of Abu Fana near Mallawi, and the ruins of ancient Coptic settlements that trace the early spread of Christianity in Upper Egypt.

The Coptic heritage of Minya stands as a testament to resilience, faith, and cultural continuity, bridging Egypt’s ancient past with its enduring Christian traditions.`,
    ar: `تُعدّ المنيا من أهم مراكز المسيحية القبطية في مصر، إذ تحتفظ بإرث روحي ومعماري مميز يعود إلى القرون الأولى للمسيحية. تضم المحافظة مجموعة من الأديرة والكنائس والمواقع المقدسة التي لا تزال تجذب الزائرين والحجاج من داخل مصر وخارجها.

من أبرز هذه المعالم **دير العذراء مريم بجبل الطير**، وهو موقع مقدّس يُعتقد أن العائلة المقدسة زارته خلال رحلتها إلى مصر. نُحت الدير داخل منحدرات الحجر الجيري المطلة على نهر النيل، ما يمنحه مشهدًا روحانيًا مهيبًا. كما تضم المنيا **كنيسة العذراء بالأشمونين (هرموبوليس)**، و**دير أبو فانا قرب ملوي**، إلى جانب بقايا مستوطنات قبطية قديمة توثّق بدايات انتشار المسيحية في صعيد مصر.

يمثل التراث القبطي في المنيا شهادة على الإيمان والصمود واستمرار الهوية الثقافية، حيث يجمع بين عبق الماضي المصري القديم وجذور التقاليد المسيحية الراسخة.`
  },
  excerpt: {
    en: 'Discover Minya’s Coptic monasteries and churches — from Gabal al-Tayr to Abu Fana — preserving centuries of faith and history.',
    ar: 'اكتشف الأديرة والكنائس القبطية في المنيا — من جبل الطير إلى دير أبو فانا — التي تحفظ قرونًا من الإيمان والتاريخ.'
  },
  imageUrl: 'assets/images/التراث القبطي في المنياn.jpg',
  author: {
    en: 'Dr. Mariam Nashed',
    ar: 'الدكتورة مريم ناشد'
  },
  publishDate: new Date('2024-08-01'),
  category: {
    en: 'History & Culture',
    ar: 'التاريخ والثقافة'
  },
  tags: [
    [
      { en: 'Coptic Heritage', ar: 'التراث القبطي' },
      { en: 'Gabal al-Tayr Monastery', ar: 'دير جبل الطير' },
      { en: 'Abu Fana Monastery', ar: 'دير أبو فانا' },
      { en: 'Holy Family Route', ar: 'مسار العائلة المقدسة' },
      { en: 'Minya', ar: 'المنيا' }
    ]
  ],
  readTime: 7,
  featured: false
},
{
  id: '5',
  title: { 
    en: 'The Nile Corniche: Modern Life Meets History', 
    ar: 'كورنيش النيل في المنيا: تلاقي الحياة العصرية مع التاريخ' 
  },
  content: { 
    en: 'The Nile Corniche in Minya is a beautiful blend of modern urban life and ancient heritage. Stretching along the eastern bank of the Nile, it offers locals and visitors a serene space to relax while overlooking the timeless river that has shaped Egypt’s civilization. Cafes, parks, and walkways make it a vibrant spot for social gatherings and evening strolls.',
    ar: 'يُعد كورنيش النيل في المنيا مزيجًا رائعًا من الحياة العصرية والتراث القديم. يمتد على الضفة الشرقية لنهر النيل، ليمنح السكان والزوار مساحة هادئة للاسترخاء ومشاهدة النهر الخالد الذي شكل حضارة مصر. تنتشر على طوله المقاهي والحدائق والممرات التي تجعله وجهة نابضة بالحياة للتنزه والتجمعات المسائية.'
  },
  excerpt: { 
    en: 'Enjoy a walk along the Nile Corniche in Minya — where modern cafes, green spaces, and the eternal Nile meet in harmony.',
    ar: 'استمتع بجولة على كورنيش النيل في المنيا، حيث تلتقي المقاهي الحديثة والمساحات الخضراء بنهر النيل الخالد في مشهد متناغم.'
  },
  imageUrl: 'assets/images/122931-كورنيش-نيل-المنيا-يتزين-بالمواطنين-بعد-إعادة-افتتاحه-(21).jpeg',
  author: { 
    en: 'Omar Nabil', 
    ar: 'عمر نبيل' 
  },
  publishDate: new Date('2024-09-25'),
  category: { 
    en: 'Attractions', 
    ar: 'المعالم السياحية' 
  },
  tags: [
    [
      { en: 'Nile Corniche', ar: 'كورنيش النيل' },
      { en: 'Minya City', ar: 'مدينة المنيا' },
      { en: 'Urban Egypt', ar: 'المدن المصرية' },
      { en: 'Modern Egypt', ar: 'مصر الحديثة' }
    ]
  ],
  readTime: 5,
  featured: false
},
{
  id: '7',
  title: { 
    en: 'Travel Tips for Exploring Minya', 
    ar: 'نصائح السفر لاكتشاف المنيا' 
  },
  content: { 
    en: `Minya, often called the "Bride of Upper Egypt," offers a mix of ancient wonders and authentic Egyptian charm. Whether you’re visiting for its archaeological sites, vibrant Corniche, or peaceful countryside, here are essential tips to make the most of your journey.

🌞 **Best Time to Visit:**  
The ideal months are from October to April when the weather is mild and perfect for sightseeing. Avoid the peak summer heat between June and August.

🚗 **Getting Around:**  
Minya is easily accessible by train or private car from Cairo. Within the city, taxis, microbuses, and Nile ferries are available. Hiring a local guide can enrich your experience, especially when exploring sites like Beni Hassan or Tell el-Amarna.

🏨 **Where to Stay:**  
Choose hotels near the Corniche or central Minya for convenient access to attractions. Options range from budget-friendly lodges to upscale stays like the Grand Aton Hotel.

🍴 **Food & Local Delights:**  
Don’t miss traditional Upper Egyptian dishes such as *feteer meshaltet*, *molokhia with rabbit*, and *sugarcane juice*. Local restaurants along the Nile offer great food with scenic views.

🕌 **Cultural Etiquette:**  
Dress modestly, especially in rural areas and religious sites. Always ask before taking photos of people, and greet locals with a warm smile — Minya’s hospitality is unmatched.

With its deep history, welcoming locals, and natural beauty, Minya promises an unforgettable Egyptian adventure.`,
    
    ar: `تُعرف المنيا باسم "عروس الصعيد"، وتجمع بين عراقة التاريخ وسحر الحياة المصرية الأصيلة. سواء جئت لاستكشاف آثارها القديمة أو الاستمتاع بكورنيش النيل أو الريف الهادئ، فإليك أهم النصائح لجعل رحلتك تجربة لا تُنسى.

🌞 **أفضل وقت للزيارة:**  
الفترة من أكتوبر إلى أبريل هي الأنسب، حيث يكون الجو معتدلًا ومثاليًا للتنزه. يُفضل تجنب شهور الصيف الحارة (يونيو إلى أغسطس).

🚗 **وسائل التنقل:**  
يمكن الوصول إلى المنيا بسهولة بالقطار أو السيارة من القاهرة. داخل المدينة، تتوفر سيارات الأجرة والميكروباص والعبّارات النيلية. يُنصح بالاستعانة بمرشد محلي خاصة عند زيارة مواقع مثل بني حسن أو تل العمارنة.

🏨 **أماكن الإقامة:**  
اختر الفنادق القريبة من كورنيش النيل أو وسط المدينة لسهولة الوصول إلى المعالم. تتنوع الخيارات بين فنادق اقتصادية وأخرى راقية مثل فندق جراند أتون.

🍴 **الأطعمة المحلية:**  
لا تفوّت تجربة أكلات الصعيد التقليدية مثل الفطير المشلتت، الملوخية بالأرانب، وعصير القصب الطازج. توجد مطاعم رائعة على ضفاف النيل تقدم أجواء ممتعة.

🕌 **آداب الثقافة:**  
احرص على ارتداء ملابس محتشمة خصوصًا في القرى والمناطق الدينية، واطلب الإذن قبل تصوير الأشخاص. التحية بابتسامة ستفتح لك قلوب أهل المنيا المعروفين بكرمهم.

المنيا مزيج فريد من التاريخ العريق والناس الطيبين والجمال الطبيعي، وهي وجهة مثالية لاكتشاف قلب مصر الحقيقي.`
  },
  excerpt: { 
    en: 'Plan your perfect trip to Minya with tips on when to visit, where to stay, what to eat, and how to explore Egypt’s hidden gem.',
    ar: 'خطط لرحلتك المثالية إلى المنيا من خلال نصائح حول أفضل وقت للزيارة، وأماكن الإقامة، والمأكولات المحلية، وأبرز أماكن الاستكشاف.'
  },
  imageUrl: 'assets/images/Travel Tips.jpg',
  author: { 
    en: 'Nour El-Din Samir', 
    ar: 'نور الدين سمير' 
  },
  publishDate: new Date('2024-10-01'),
  category: { 
    en: 'Travel Tips', 
    ar: 'نصائح السفر' 
  },
  tags: [
    [
      { en: 'Travel Tips', ar: 'نصائح السفر' },
      { en: 'Minya', ar: 'المنيا' },
      { en: 'Egypt Travel', ar: 'السفر في مصر' },
      { en: 'Upper Egypt', ar: 'صعيد مصر' }
    ]
  ],
  readTime: 6,
  featured: false
}
,
{
  id: '7',
  title: { 
    en: 'Top Attractions in Minya', 
    ar: 'أبرز المعالم السياحية في المنيا' 
  },
  content: { 
    en: 'Minya is filled with incredible attractions that blend ancient history, religious heritage, and modern beauty. From the tombs of Beni Hassan to the city of Tell el-Amarna, visitors can experience Egypt’s story across different eras. The Nile Corniche offers a peaceful riverside walk, while the Coptic churches reflect the region’s deep spiritual roots.', 
    ar: 'تزخر المنيا بالعديد من المعالم السياحية المدهشة التي تجمع بين التاريخ القديم والتراث الديني والجمال الحديث. من مقابر بني حسن إلى مدينة تل العمارنة، يمكن للزائرين أن يعيشوا قصة مصر عبر العصور المختلفة. يوفر كورنيش النيل نزهة هادئة على ضفاف النيل، بينما تعكس الكنائس القبطية الجذور الروحية العميقة للمنطقة.' 
  },
  excerpt: { 
    en: 'Explore Minya’s top attractions that highlight its rich blend of ancient wonders, Coptic heritage, and scenic Nile views.', 
    ar: 'اكتشف أبرز معالم المنيا التي تجمع بين روائع التاريخ القديم والتراث القبطي ومناظر النيل الخلابة.' 
  },
  imageUrl: 'assets/images/Top Attractions in Minya.jpg',
  author: { 
    en: 'Nour El-Din Khaled', 
    ar: 'نور الدين خالد' 
  },
  publishDate: new Date('2024-09-25'),
  category: { 
    en: 'History & Culture', 
    ar: 'التاريخ والثقافة' 
  },
  tags: [
    [
      { en: 'Minya Attractions', ar: 'معالم المنيا' },
      { en: 'Tourism', ar: 'السياحة' },
      { en: 'Egypt Travel', ar: 'السفر في مصر' }
    ]
  ],
  readTime: 7,
  featured: false
},

{
  id: '11',
  title: { 
    en: 'Al Minya Cultural Festival', 
    ar: 'مهرجان المنيا الثقافي' 
  },
  content: { 
    en: 'Held annually along the Nile Corniche, the Al Minya Cultural Festival celebrates local art, crafts, and traditional music. It brings together artists, musicians, and families to honor Minya’s vibrant identity.', 
    ar: 'يُقام مهرجان المنيا الثقافي سنويًا على كورنيش النيل، ويحتفي بالفنون المحلية والحرف والموسيقى التقليدية، حيث يجتمع الفنانون والعائلات للاحتفال بهوية المنيا النابضة بالحياة.' 
  },
  excerpt: { 
    en: 'A vibrant celebration of art, music, and heritage along the Nile.', 
    ar: 'احتفال نابض بالفن والموسيقى والتراث على ضفاف النيل.' 
  },
  imageUrl: '/assets/images/مهرجان المنيا الثقافي.jpg',
  author: { 
    en: 'Minya Governorate', 
    ar: 'محافظة المنيا' 
  },
  publishDate: new Date('2024-03-10'),
  category: { 
    en: 'Events & Festivals', 
    ar: 'الفعاليات والمهرجانات' 
  },
  tags: [
    [
      { en: 'Culture', ar: 'ثقافة' },
      { en: 'Festival', ar: 'مهرجان' },
      { en: 'Art', ar: 'فن' }
    ]
  ],
  readTime: 5,
  featured: true
}
,
{
  id: '13',
  title: { 
    en: 'Minya Music & Arts Week', 
    ar: 'أسبوع الموسيقى والفنون بالمنيا' 
  },
  content: { 
    en: 'This annual event brings together local bands, art exhibitions, and workshops for youth and children, encouraging creativity and artistic expression throughout the governorate.', 
    ar: 'فعالية سنوية تجمع بين الفرق الموسيقية المحلية والمعارض الفنية وورش العمل للأطفال والشباب، لتعزيز الإبداع والتعبير الفني في جميع أنحاء المحافظة.' 
  },
  excerpt: { 
    en: 'A colorful celebration of Minya’s modern artistic spirit.', 
    ar: 'احتفال مليء بالألوان يبرز روح المنيا الفنية الحديثة.' 
  },
  imageUrl: '/assets/images/أسبوع الموسيقى والفنون بالمنيا.jpg',
  author: { 
    en: 'Mekano Labs & Minya Cultural Center', 
    ar: 'ميكانو لابز ومركز المنيا الثقافي' 
  },
  publishDate: new Date('2024-12-15'),
  category: { 
    en: 'Events & Festivals', 
    ar: 'الفعاليات والمهرجانات' 
  },
  tags: [
    [
      { en: 'Music', ar: 'موسيقى' },
      { en: 'Art', ar: 'فن' },
      { en: 'Youth', ar: 'شباب' }
    ]
  ],
  readTime: 5,
  featured: false
}
,
{
  id: '14',
  title: { 
    en: 'Nile Boat Festival', 
    ar: 'مهرجان القوارب على النيل' 
  },
  content: { 
    en: 'The Nile Boat Festival is one of Minya’s most picturesque events, where decorated boats parade along the Nile in a stunning display of colors, music, and joy. Families gather to enjoy traditional food, performances, and fireworks at night.', 
    ar: 'يُعد مهرجان القوارب على النيل من أجمل فعاليات المنيا، حيث تستعرض القوارب المزينة بألوان زاهية على النيل وسط أجواء من الموسيقى والفرح. تجتمع العائلات للاستمتاع بالأطعمة التقليدية والعروض والألعاب النارية ليلًا.' 
  },
  excerpt: { 
    en: 'A lively festival celebrating the beauty of the Nile and Minya’s joyful spirit.', 
    ar: 'مهرجان مبهج يحتفي بجمال النيل وروح المنيا المرحة.' 
  },
  imageUrl: 'assets/images/صور مهرجان القوارب على النيل ف المنيا.jpg',
  author: { 
    en: 'Tourism Directorate of Minya', 
    ar: 'مديرية السياحة بالمنيا' 
  },
  publishDate: new Date('2024-05-20'),
  category: { 
    en: 'Events & Festivals', 
    ar: 'الفعاليات والمهرجانات' 
  },
  tags: [
    [
      { en: 'Festival', ar: 'مهرجان' },
      { en: 'Nile', ar: 'نيل' },
      { en: 'Culture', ar: 'ثقافة' }
    ]
  ],
  readTime: 5,
  featured: true
}
,
{
  id: '15',
  title: { 
    en: 'Agricultural Fair of Minya', 
    ar: 'المعرض الزراعي بالمنيا' 
  },
  content: { 
    en: 'The Agricultural Fair showcases Minya’s thriving agricultural sector, featuring exhibitions of local produce, modern farming technologies, and workshops for farmers. It highlights the governorate’s role as a major food producer in Upper Egypt.', 
    ar: 'يُبرز المعرض الزراعي ازدهار القطاع الزراعي في المنيا من خلال معارض للمنتجات المحلية والتقنيات الزراعية الحديثة وورش عمل للمزارعين، ويؤكد دور المحافظة كمركز رئيسي لإنتاج الغذاء في صعيد مصر.' 
  },
  excerpt: { 
    en: 'An event dedicated to innovation, sustainability, and the future of farming in Minya.', 
    ar: 'فعالية مخصصة للابتكار والاستدامة ومستقبل الزراعة في المنيا.' 
  },
  imageUrl: '/assets/images/المعرض الزراعي بالمنيا.jpg',
  author: { 
    en: 'Minya Agriculture Directorate', 
    ar: 'مديرية الزراعة بالمنيا' 
  },
  publishDate: new Date('2024-11-25'),
  category: { 
    en: 'Events & Festivals', 
    ar: 'الفعاليات والمهرجانات' 
  },
  tags: [
    [
      { en: 'Agriculture', ar: 'زراعة' },
      { en: 'Innovation', ar: 'ابتكار' },
      { en: 'Local Economy', ar: 'الاقتصاد المحلي' }
    ]
  ],
  readTime: 6,
  featured: false
}
,
{
  id: '16',
  title: {
    en: 'Coptic Art & Heritage Festival',
    ar: 'مهرجان التراث والفنون القبطية'
  },
  content: {
    en: `The Coptic Art & Heritage Festival celebrates the living traditions of Minya’s Coptic community through exhibitions, liturgical music performances, iconography workshops, and guided visits to historic monasteries and churches. The festival highlights ancient crafts, manuscript conservation demonstrations, and lectures by Coptic scholars, offering both spiritual reflection and cultural learning for visitors of all backgrounds.`,
    ar: `يحتفي مهرجان التراث والفنون القبطية بتقاليد المجتمع القبطي في المنيا من خلال معارض، عروض للترانيم القبطية، ورش عمل في فن الأيقونات، وزيارات إرشادية للأديرة والكنائس التاريخية. يبرز المهرجان الحرف القديمة، وعروضًا لحفظ المخطوطات، ومحاضرات لعلماء قبطيين، ما يوفر تجربة ثقافية وروحانية للزوار من مختلف الخلفيات.`
  },
  excerpt: {
    en: 'A festival of Coptic art, music, and heritage — workshops, concerts, and visits to Minya’s sacred sites.',
    ar: 'مهرجان للفن والترات القبطية — ورش، حفلات، وزيارات لمواقع المنيا المقدسة.'
  },
  imageUrl: '/assets/images/مهرجان التراث والفنون القبطية ف المنيا صور.jpg',
  author: {
    en: 'Coptic Cultural Committee - Minya',
    ar: 'اللجنة القبطية للثقافة - المنيا'
  },
  publishDate: new Date('2024-12-05'),
  category: {
    en: 'Events & Festivals',
    ar: 'الفعاليات والمهرجانات'
  },
  tags: [
    [
      { en: 'Coptic Heritage', ar: 'التراث القبطي' },
      { en: 'Iconography', ar: 'فن الأيقونات' },
      { en: 'Liturgical Music', ar: 'الموسيقى الطقسية' },
      { en: 'Monasteries', ar: 'الأديرة' }
    ]
  ],
  readTime: 5,
  featured: false
},
{
  id: '17',
  title: { 
    en: 'Hermopolis Magna: The Ancient City of Thoth', 
    ar: 'الأشمونين: مدينة الإله تحوت القديمة' 
  },
  content: { 
    en: `Hermopolis Magna, known in ancient Egyptian as Khmunu and in Arabic as Al-Ashmunein, lies about 7 km west of Mallawi in Minya Governorate. It was the capital of the 15th Upper Egyptian nome and a major religious and cultural center dedicated to the god Thoth — the deity of wisdom, writing, and science. During the Pharaonic, Greco-Roman, and even Coptic periods, Hermopolis remained an influential city, blending spiritual and intellectual heritage.

The site features grand temple ruins, including the Temple of Thoth, built initially in the New Kingdom and later expanded by Ramses II. The massive stone columns and reliefs still reflect the majesty of the ancient city. Excavations also revealed remnants of Ptolemaic and Roman houses, statues, and inscriptions showing the continuity of worship of Thoth. Nearby, archaeologists discovered a large necropolis with elaborate tombs and sarcophagi.

In Coptic times, Hermopolis became a significant Christian center, with several churches built over older temples. Today, the ruins stand as a testament to Minya’s layered history — a place where Pharaonic gods, Hellenistic culture, and Christian art once coexisted in harmony.`, 

    ar: `تقع مدينة الأشمونين، التي كانت تُعرف في مصر القديمة باسم خمنو، على بُعد نحو 7 كيلومترات غرب ملوي بمحافظة المنيا. كانت عاصمة المقاطعة الخامسة عشرة من أقاليم مصر العليا، ومركزًا دينيًا وثقافيًا هامًا مكرسًا لعبادة الإله تحوت — إله الحكمة والكتابة والعلم. خلال العصور الفرعونية واليونانية الرومانية وحتى القبطية، ظلت الأشمونين مدينة ذات تأثير روحي وفكري كبير، تجمع بين التراث الديني والعلمي.

يضم الموقع بقايا معابد ضخمة، من أبرزها معبد تحوت الذي بُني في عصر الدولة الحديثة وتم توسيعه في عهد رمسيس الثاني. ولا تزال الأعمدة الحجرية والنقوش البارزة تعكس عظمة المدينة القديمة. كما كشفت الحفريات عن بقايا منازل بطلمية ورومانية وتماثيل ونقوش تدل على استمرار عبادة الإله تحوت. وبالقرب من المدينة، تم اكتشاف مقبرة كبيرة تضم توابيت ونقوشًا دقيقة.

وفي العصر القبطي، أصبحت الأشمونين مركزًا مسيحيًا هامًا، حيث شُيدت عدة كنائس فوق المعابد القديمة. وتُعد أطلالها اليوم شاهدًا على التاريخ المتنوع لمحافظة المنيا، حيث تعايشت الحضارات الفرعونية واليونانية والقبطية في تناغم فريد.` 
  },
  excerpt: { 
    en: 'Explore Hermopolis Magna — the city of Thoth, wisdom, and ancient knowledge that once united Egyptian, Greek, and Coptic civilizations.', 
    ar: 'استكشف الأشمونين — مدينة تحوت، إله الحكمة والمعرفة، التي جمعت بين الحضارات المصرية واليونانية والقبطية.' 
  },
  imageUrl: 'assets/images/download.jpg',
  author: { 
    en: 'Dr. Nader Ibrahim', 
    ar: 'الدكتور نادر إبراهيم' 
  },
  publishDate: new Date('2024-10-10'),
  category: { 
    en: 'Attractions', 
    ar: 'المعالم السياحية' 
  },
  tags: [
    [
      { en: 'Hermopolis', ar: 'الأشمونين' },
      { en: 'Thoth', ar: 'الإله تحوت' },
      { en: 'Temples', ar: 'المعابد' },
      { en: 'Ancient Egypt', ar: 'مصر القديمة' },
      { en: 'Minya', ar: 'المنيا' },
      { en: 'Greco-Roman Period', ar: 'العصر اليوناني الروماني' }
    ]
  ],
  readTime: 8,
  featured: true
}






];