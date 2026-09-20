const https = require('https');

const RAW_ATTRACTIONS = [
  {
    id: '1',
    name: { en: 'Beni Hassan Tombs', ar: 'مقابر بني حسن' },
    description: {
      en: "The Beni Hasan cemetery is located in one of the most fertile regions of Egypt. This fertility led to an economic boom, and this site contains some of the most impressive Middle Kingdom cemeteries. These cemeteries are also among the best preserved to date. The cemetery consists of two parts: an upper cemetery and a lower cemetery. The lower cemetery, containing 800 tombs, lies on the slopes of the hills and includes many shaft tombs. The tombs in the lower cemetery belong to various officials from the First Intermediate Period (c. 2181–2055 BC) to the Middle Kingdom (c. 2055–1650 BC), but it also includes tombs from the late Old Kingdom (c. 2345–2181 BC), such as the tomb of Ipi. The upper cemetery contains 39 rock-cut tombs, meaning they were cut horizontally into the rock of the cliffs. The walls of 12 of these tombs are decorated with beautifully painted, detailed scenes depicting daily life, including agriculture, crafts, and various occupations, as well as a range of activities such as hunting, various games, and even scenes of war and the arrival of foreigners in Egyptian lands. The tombs of the Upper Cemetery are a testament to the architectural skills of the ancient Egyptians, meticulously carved into the rock with simple tools such as bronze-bladed chisels struck with wooden hammers. These tombs are the final resting places of the most senior officials of this region in Nome 16 of Upper Egypt. They date back to the Eleventh and Twelfth Dynasties (c. 2055–1795 BC). The recurrence of names such as Baket, Kheti, and Khnumhotep through subsequent generations suggests connections between the tomb owners.",
      ar: "تقع جبانة بني حسن بأحد أكثر المناطق خصوبة في مصر. أدت هذه الخصوبة إلى ازدهار اقتصادي، هذا الموقع يضمّ بعض مقابر الدولة الوسطى الأكثر إثارة للإعجاب. هذه المقابر من أفضل المقابر المحفوظة أيضًا حتى وقتنا الحالي. تتكون الجبانة من جزئين، علوي وسفلي. تقع الجبانة السفلية، التي تحتوي 800 مقبرة، على منحدرات التلال، وتضمّ العديد من المقابر البئرية. تخص مقابر الجبانة السفلية موظفين مختلفين من عصر الانتقال الأول(حوالي 2181-2055 ق. م) إلى الدولة الوسطى (حوالي 2055-1650ق. م) ولكن يوجد بها مقابر تابعة لأواخر عصر الدولة القديمة (حوالي 2345-2181 ق. م) مثل مقبرة إيبي. بينما تضمّ الجبانة العلوية 39 مقبرة منحوتة في الصخر، ما يعني أنها مقطوعة أفقيًا في صخور المنحدرات. زُينت جدران 12 من هذه المقابر بمشاهد مُفصلة مُرسومة بشكل جميل، وتصور مناظر من الحياة اليومية، تشمل الزراعة والحرف والمهن المختلفة، ومجموعة من الأنشطة مثل الصيد والألعاب المختلفة، وحتى مشاهد الحرب، ووصول الأجانب إلى الأراضي المصرية. تعتبر مقابر الجبانة العلوية شهادة على مهارات المصريين القدماء المعمارية، فقد نُحتت في الصخر بدقة عبر أدوات بسيطة مثل الأزاميل ذات الشفرات البرونزية التي ضُربت بمطارق خشبية. هذه المقابر هي أماكن الراحة الأبدية لكبار المسئولين في هذه المنطقة في المقاطعة رقم 16 في صعيد مصر. ويعود تاريخها إلى الأسرتين الحادية عشرة والثانية عشرة (حوالي 2055-1795 ق.م). ويوحي تكرار أسماء مثل باقت، خيتي وخنوم-حتب عبر الأجيال اللاحقة بوجود صلات تربط أصحاب هذه المقابر."
    },
    imageUrl: '/assets/images/baniHassan/bani.jpg',
    imageGallery: [
      '/assets/images/baniHassan/bani.jpg', '/assets/images/baniHassan/amenmhat.jpg', '/assets/images/baniHassan/amenmhat1.jpg',
      '/assets/images/baniHassan/amenmhat2.jpg', '/assets/images/baniHassan/amenmhat3.jpg', '/assets/images/baniHassan/baqet.jpg',
      '/assets/images/baniHassan/baqet1.jpg', '/assets/images/baniHassan/baqet2.jpg', '/assets/images/baniHassan/baqet3.jpg',
      '/assets/images/baniHassan/khity.jpg', '/assets/images/baniHassan/khity1.jpg', '/assets/images/baniHassan/khity2.jpg',
      '/assets/images/baniHassan/khity3.jpg', '/assets/images/baniHassan/khity4.jpg'
    ],
    latitude: 27.662056,
    longitude: 30.905524,
    openingHours: { en: '8:00 AM - 5:00 PM', ar: '٨:٠٠ ص - ٥:٠٠ م' },
    ticketPrice: { en: '100 EGP', ar: '١٠٠ جنيه' },
    rating: 4.7,
    reviewCount: 324,
    category: { en: 'Historical Site', ar: 'موقع تاريخي' },
    features: [
      { en: 'Guided Tours', ar: 'جولات إرشادية' },
      { en: 'Photography Allowed', ar: 'يسمح بالتصوير' },
      { en: 'Wheelchair Accessible', ar: 'مناسب لذوي الاحتياجات الخاصة' }
    ],
    historicalPeriod: {
      en: 'Middle Kingdom (2055–1650 BC)',
      ar: 'الدولة الوسطى (٢٠٥٥–١٦٥٠ قبل الميلاد)'
    },
    significance: {
      en: "Tomb of Amenemhat :\nAmenemhat was the last to hold the title of Governor of the Nome (the Ibex Province). He held this position for approximately 25 years, during the reign of the Twelfth Dynasty king, Senusret I (c. 1965–1920 BC). As with Khnumhotep II, the entrance to the tomb takes the form of a two-columned portico flanked by a forecourt, accessed by a path ascending the hill. Here too, its path can still be seen thanks to the rocks on either side. In the center of the eastern wall facing the entrance is a shrine containing the remains of a statue of Amenemhat, his wife Hetpet, and his mother Henu. Amenemhat's tomb stands out from the rest of the Beni Hasan tombs for its brightly painted reliefs, which include scenes from daily life such as agriculture, fishing, and hunting birds, as well as depictions of various crafts and occupations, including carpentry, sandal-making, pottery, and bows and arrows. The ceiling of the hypostyle hall is also striking, with a yellow rectangle in the center of each section bearing hieroglyphic inscriptions. The center of this rectangle is surrounded by a red and yellow drawing in another, larger rectangle with a frame resembling a mat pattern. A number of red and yellow squares are arranged around it.\n\nKheti's Tomb: \nKheti was the ruler of the 16th Nome. His tomb dates back to (c. 2055-1956 BC) in the Middle Kingdom. The tomb consists of a forecourt leading to the entrance and a room with two rows of three columns topped with lotus capitals. Only one column of each row remains. The walls of this tomb contain many interesting scenes, such as the wrestling scenes on the eastern wall, which depict wrestlers in various poses and military exercises arranged in three rows in preparation for storming castles and fortresses. Facing the entrance are 122 pairs of wrestlers in five rows, no two in the same position. Below the wrestlers are scenes of defenders of a fortified position engaging in combat with their besiegers. The northern wall (to the left of the entrance), as is typical of the tombs of the Upper Cemetery at Beni Hasan, depicts scenes of hunting wild animals in the desert. In the rows below, barbers can be seen, along with carpentry scenes. This is followed by a carved scene of the tomb owner and his wife, along with scenes of funerary rituals, spinning, weaving, and playing board games, and young women playing and performing acrobatics. Khety and his wife watch all these activities and can be seen far below this same wall. The southern wall is also decorated with several scenes depicting winemaking, listening to music, and performing various physical exercises.\n\nThe Tomb of Baqet III : \nThis tomb belonged to Baqet III, son of Remu-Shen, both of whom were governors of the Sixteenth Nome of Upper Egypt, during the early Twelfth Dynasty. The tomb consists of a courtyard leading to the entrance, which provides access to the hypostyle hall. A small chapel was added in the southeast corner (on the far right), where a false door is carved on the west wall, in front of which is an offering table. The walls of the tomb, like those of other tombs at Beni Hasan, feature a decorative frieze at the top, called the \"khekr\" by the ancient Egyptians. As is typical of the tombs of the Upper Cemetery at Beni Hasan, the northern wall (left of the entrance) depicts scenes of hunting in the desert. This same wall, like the tomb of Khety, depicts scenes of daily life. It depicts barbers, spinning and weaving, and young women playing and performing acrobatics. This wall also features scenes of sandal makers and goldsmiths, and a tax collection scene where defaulters are forcibly brought before a scribe. Also of interest is the row at the bottom, which, in addition to hunting, depicts various species of fish and flying creatures, mostly birds, but also includes bats. More animals can be seen on the southern wall, where a cat and a mouse confront each other, and below them are two monkeys, a male and a female, the latter carrying a baby monkey on her back. Nearby are two baboons. The eastern wall depicts scenes of gladiators and military training, and, more prominently, pairs of gladiators. There are many of them here: 220 pairs, to be exact, all in various poses. In each pair, one wrestler is painted red and the other dark brown so that the interaction between them can be clearly seen.\n\nTomb of Khnumhotep II :\nKhnumhotep II was the overseer of the Eastern Desert and served under King Senusret II in the Twelfth Dynasty.\nThe entrance to the hypostyle hall of Khnumhotep's tomb is preceded by a portico with two columns in a forecourt. In ancient times, access to the forecourt was via a long ascent, the path of which can still be seen thanks to the rocks on either side. The portico has two polygonal columns. Because of its similarity to Greek Doric columns, this style of column is called \"Proto-Doric.\" The hypostyle hall contains two burial shafts and is designed with two rows of columns arranged in a square around its center. This hall ends with a statue shrine. Khnumhotep recorded his autobiography in 222 lines of text that run along the lower walls of the hypostyle hall. On either side of the statue's chapel, he can be seen hunting fish and birds in nature. The most famous scene in the tomb is on the north wall (to the left of the entrance), where a delegation of \"Ammu\" (the word the ancient Egyptians used to refer to the people who lived to the east and northeast of Egypt) is depicted. This delegation consists of men, women, and children, dressed in beautiful and colorful clothing. The hieroglyph above them identifies them as a delegation of 37 Ammu bringing eye paint. The head of the delegation, Abi-Shai, is also titled \"Heqa-Khaset,\" meaning \"ruler of a foreign land.\" This is the earliest known example of the word now known in Greek as Hyksos.\nOn the west wall, you'll notice a fascinating scene depicting three monkeys helping workers gather figs from a tree!",
      ar: "مقبرة أمنمحات:\nكان أمنمحات آخر مَن يحمل لقب حاكم المقاطعة (إقليم الوعل). وقد شغل هذا المنصب لمدة 25 عامًا تقريبًا، في عهد ملك الأسرة الثانية عشرة ، سنوسرت الأول (حوالي 1965-1920 ق.م). كما هو الحال مع خنوم-حتب الثاني، فإن مدخل المقبرة على شكل رواق به عمودان محاط بفناء أمامي، ويتم الوصول إليه من خلال ممر يصعد التل. هُنا أيضًا، لا يزال من الممكن رؤية مساره بفضل الصخور الموجودة على جانبيه. ويتوسط الجدار الشرقي المواجه للمدخل مقصورة تحتوي على بقايا تمثال لأمنمحات، وزوجته حتبت، ووالدته حنو. تتميز مقبرة أمنمحات عن بقية مقابر بني حسن برسومها الزاهية، والتي تشمل مناظر من الحياة اليومية مثل الزراعة وصيد الأسماك والطيور، وتصوير مختلف الحرف والمهن، ومنها النجارة وصناعة الصنادل والفخار والأقواس والسهام. كما يلفت سقف صالة الأعمدة النظر، حيث نرى بمنتصف كل جزء منه مستطيلًا أصفر اللون، ويحمل كتابة هيروغليفية. ويحيط بوسط هذا المستطيل رسم أحمر وأصفر في مستطيل آخر أكبر ذو إطار يشبه نمط يقلد الحصيرة. وتتراص حوله عدد من المربعات الحمراء والصفراء.\n\nمقبرة خيتي :\nكان خيتي حاكم المقاطعة السادسة عشر. يرجع تاريخ مقبرته إلى (حوالي 2055- 1956 ق.م) في الدولة الوسطى . وتتكون المقبرة من ساحة أمامية تؤدي إلى المدخل، وغرفة بها صفان من ثلاثة أعمدة تعلوها تيجان اللوتس. لم يبق من كل صف إلا عمودًا. يوجد على جدران هذه المقبرة العديد من المناظر المثيرة للاهتمام كمناظر المصارعة على الجدار الشرقي، حيث يظهر المصارعون في أوضاع حركية مختلفة والتدريبات العسكرية على شكل ثلاثة صفوف استعدادًا لاقتحام القلاع والحصون. في مواجهة المدخل 122 زوجًا من المصارعين في خمسة صفوف، ولا يوجد اثنان في نفس الوضعية. وأسفل المصارعين، توجد مناظر مدافعين محاصرين بموقع محصّن، في قتال مع محاصريهم. يصور الجدار الشمالي (على يسار المدخل)، كما هو مُعتاد بمقابر الجبانة العُليا ببني حسن، مناظر صيد الحيوانات البرية في الصحراء. في الصفوف أدناه، يمكن رؤية الحلاقين، بالإضافة إلى مشاهد النجارة، ويلي ذلك منظر يُنحت لصاحب المقبرة وزوجته إلى جانب مناظر الطقوس الجنائزية، ومناظر الغزل والنسيج واللعب بألعاب الطاولة، والشابات يلعبن ويؤدين الألعاب البهلوانية. يشاهد خيتي وزوجته كل هذه الأنشطة، ويمكن رؤيتهما بعيدًا أسفل هذا الجدار نفسه. كما يزين الجدار الجنوبي عدد من المناظر تمثل مراحل صناعة النبيذ والاستماع الى الموسيقى وأداء التمرينات الرياضية المختلفة.\n\nمقبرة باقت الثالث :\nتخص هذه المقبرة إلى باقت الثالث ابن رِمو شن، وكلاهما كان من حكام المقاطعة السادسة عشر في مصر العليا، في أوائل الأسرة الثانية عشرة. تتكون المقبرة من ساحة تؤدي إلى المدخل الذي يتيح الوصول إلى صالة الأعمدة. وأُضيف هناك مقصورة صغيرة في الزاوية الجنوبية الشرقية (في أقصى اليمين) حيث نقش باب وهمي على الجدار الغربي، وأمامه مائدة لتقديم القرابين.\nتحتوي جدران المقبرة، مثل تلك الموجودة في مقابر أخرى في بني حسن، على إفريز زخرفي في الأعلى، أطلق عليه المصريون القدماء اسم «خِكر». كما هو الحال بالنسبة لمقابر الجبانة العليا ببني حسن، فإن الجدار الشمالي (يسار المدخل) يصور مناظر الصيد في الصحراء. هذا الجدار نفسه، مثل مقبرة خيتي، يصور مناظر الحياة اليومية. فيصور الحلاقين بالإضافة إلى مناظر الغزل والنسيج، وشابات يلعبن ويؤدين الألعاب البهلوانية. هذا الجدار يحمل كذلك مناظر لصانعي الصنادل والصاغة، ومنظر تحصيل الضرائب حيث يُجلب المتعثرون بالقوة أمام كاتب. ومن المثير للاهتمام أيضًا الصف الموجود في الجزء السفلي والذي يصور، إلى جانب الصيد، أنواعًا مختلفة من الأسماك والمخلوقات الطائرة، معظمها من الطيور، وتضمّ أيضًا الخفافيش. يمكن رؤية المزيد من الحيوانات على الجدار الجنوبي، حيث تواجه قطة وفأرًا، ويوجد تحتهما قردان، ذكر وأنثى، والأخيرة تحمل قردًا صغيرًا على ظهرها. وفي الجوار، اثنان من قرود البابون. ويصور الجدار الشرقي مناظر المصارعين والتدريبات العسكرية، وبشكل أكثر بروزًا، أزواج من المصارعين. يوجد الكثير منهم هنا: 220 زوجًا، على وجه الدقة، كلها في وضعيات مختلفة، وفي كل زوج، طُلي أحد المصارعين باللون الأحمر والآخر باللون البني الداكن حتى يمكن رؤية التفاعل بينهما بوضوح.\n\nمقبرة خنوم حتب الثاني :\nكان خنوم حتب الثاني المُشرف على الصحراء الشرقية، وخدم في عهد الملك سنوسرت الثاني في الأسرة الثانية عشرة.\nويتقدم مدخل صالة الأعمدة بمقبرة خنوم-حتب رواق به عمودان في ساحة أمامية. قديمًا، كان الوصول إلى الفناء الأمامي عبر طريق صاعد طويل، لا يزال ممكنًا رؤية مساره بفضل الصخور الموجودة على جانبيه. يحتوي الرواق على عمودين مضلعين. ونظرًا لتشابهه مع الأعمدة الدورية اليونانية، يطلق على هذا النمط من الأعمدة «بروتو-دوريك». تحتوي صالة الأعمدة على بئرين للدفن، وقد صُممت بصفين من الأعمدة في شكل مربع حول منتصفها، وتنتهي هذه الصالة بمقصورة التمثال.\nسجل خنوم-حتب سيرته الذاتية في 222 سطرا نصيًا يمر عبر الجزء السفلي من جدران صالة الأعمدة. على جانبي مقصورة التمثال، يمكن رؤيته يصطاد الأسماك والطيور في الطبيعة. ويُعتبر أشهر منظر بالمقبرة هو الموجود على الجدار الشمالي (على يسار المدخل)، حيث يوجد وفد من الـ«عامو» (الكلمة التي استخدمها المصريون القدماء للإشارة إلى الأشخاص الذين عاشوا في الشرق وشمال الشرق من مصر). ويتكون هذا الوفد من رجال ونساء وأطفال يرتدون ملابس جميلة وملونة. يحدد خط الكتابة الهيروغليفي فوقهم أنهم وفد من 37 عاموًا يجلبون طلاءً للعين. كما يوجد لقب لرئيس الوفد وهو أبي شاي والذي يُعرف بأنه «حقا-خاسيت» وتعني «حاكم أرض أجنبية». هذا هو أقدم مثال معروف للكلمة التي اشتهرت اليوم باللغة اليونانية الهكسوس(Hyksos).\nعلى الجدار الغربي، ستلاحظ منظرًا رائعًا يصور ثلاثة قرود تساعد العمال في جمع التين من الشجرة!"
    },
    bookingUrl: 'https://egymonuments.com/details/BeniHassanTomb'
  },
  {
    id: '2',
    name: { en: 'Tuna el-Gebel', ar: 'تونة الجبل' },
    description: {
      en: "Tuna el-Gebel is one of Egypt’s most remarkable archaeological sites, serving as the necropolis of Hermopolis Magna (ancient Khmunu). It reflects a unique blend of Pharaonic, Greek, and Roman funerary art and architecture...",
      ar: "تُعد تونة الجبل من أبرز المناطق الأثرية في مصر، وكانت جبانة مدينة الأشمونين (خمنو القديمة)، وتُجسِّد مزيجاً فريداً بين الفن الجنائزي المصري القديم واليوناني والروماني..."
    },
    imageUrl: '/assets/images/tuna/tunaelgabel.jpeg',
    imageGallery: [
      '/assets/images/tuna/tunaelgabel.jpeg', '/assets/images/tuna/tuna14.jpg', '/assets/images/tuna/tuna12.jpg',
      '/assets/images/tuna/tuna6.jpg', '/assets/images/tuna/tuna5.jpg', '/assets/images/tuna/tuna3.jpg',
      '/assets/images/tuna/tuna1.jpg', '/assets/images/bitozeris/bitozeris.jpg', '/assets/images/bitozeris/bitozeris1.jpg'
    ],
    latitude: 27.773628,
    longitude: 30.738468,
    openingHours: { en: '8:00 AM - 4:00 PM', ar: '٨:٠٠ ص - ٤:٠٠ م' },
    ticketPrice: { en: '80 EGP', ar: '٨٠ جنيه' },
    rating: 4.5,
    reviewCount: 198,
    category: { en: 'Archaeological Site', ar: 'موقع أثري' },
    features: [
      { en: 'Guided Tours', ar: 'جولات إرشادية' },
      { en: 'Museum', ar: 'متحف' },
      { en: 'Gift Shop', ar: 'متجر هدايا' },
      { en: 'Underground Catacombs', ar: 'سراديب تحت الأرض' },
      { en: 'Rock-cut Tombs', ar: 'مقابر منحوتة في الصخر' }
    ],
    historicalPeriod: {
      en: 'Late Period to Greco-Roman Period (664 BC – 395 AD)',
      ar: 'من العصر المتأخر حتى العصرين اليوناني والروماني (٦٦٤ ق.م – ٣٩٥ م)'
    },
    significance: {
      en: 'A vast Greco-Roman necropolis that preserves a complete funerary landscape blending Egyptian and Hellenistic art, with temples, tombs, and sacred animal catacombs linked to the god Thoth.',
      ar: 'جبانة واسعة من العصرين اليوناني والروماني، تُحافظ على مشهد جنائزي متكامل يجمع بين الفن المصري القديم والهلنستي، وتضم معابد ومقابر وسراديب الحيوانات المقدسة المرتبطة بالإله تحوت.'
    },
    bookingUrl: 'https://egymonuments.com/details/Tunael-Gebel'
  },
  {
    id: '3',
    name: { en: 'Tell el-Amarna', ar: 'تل العمارنة' },
    description: {
      en: "Akhenaten's Capital The first to call for monotheism, King Amenhotep IV (c. 1351-1336 BC) carried out what is often described as a religious revolution...",
      ar: "عاصمة أخناتون أول من نـادى بالتوحيـد قــام المــلك أمنحتب الرابـــع (حوالي ١٣٥١ - ١٣٣٦ ق.م) بما يوصف غالبـــا بـــأنها ثـــــــورة دينيــــــة..."
    },
    imageUrl: '/assets/images/tel_amarna/tel_amarna3.jpg',
    imageGallery: [
      '/assets/images/tel_amarna/tel_amarna1.jpg', '/assets/images/tel_amarna/tel_amarna2.jpg', '/assets/images/tel_amarna/tel_amarna3.jpg',
      '/assets/images/tel_amarna/tel_amarna4.jpg', '/assets/images/tel_amarna/tel_amarna5.jpg', '/assets/images/tel_amarna/tel_amarna6.jpg'
    ],
    latitude: 27.662056,
    longitude: 30.905524,
    openingHours: { en: '8:00 AM - 5:00 PM', ar: '٨:٠٠ ص - ٥:٠٠ م' },
    ticketPrice: { en: '120 EGP', ar: '١٢٠ جنيه' },
    rating: 4.6,
    reviewCount: 156,
    category: { en: 'Archaeological Site', ar: 'موقع أثري' },
    features: [
      { en: 'Archaeological Tours', ar: 'جولات أثرية' },
      { en: 'Museum', ar: 'متحف' },
      { en: 'Gift Shop', ar: 'متجر هدايا' }
    ],
    historicalPeriod: {
      en: 'New Kingdom – Amarna Period (1351–1334 BC)',
      ar: 'الدولة الحديثة – فترة العمارنة (١٣٥١ - ١٣٣٤ ق.م)'
    },
    significance: {
      en: 'Capital city of Pharaoh Akhenaten and center of a monotheistic revolution',
      ar: 'عاصمة الفرعون إخناتون ومركز التحول إلى التوحيد'
    },
    bookingUrl: 'https://egymonuments.com/details/Amarna'
  },
  {
    id: '4',
    name: { en: 'Minya Corniche', ar: 'كورنيش المنيا' },
    description: {
      en: 'A beautiful waterfront promenade along the Nile River, perfect for evening walks and enjoying sunset views.',
      ar: 'ممشى جميل على ضفاف النيل، مثالي للتنزه مساءً والاستمتاع بغروب الشمس.'
    },
    imageUrl: '/assets/images/kornish/kornish4.jpg',
    imageGallery: [
      '/assets/images/kornish/kornish4.jpg', '/assets/images/kornish/kornish.png', '/assets/images/kornish/kornish1.jpg',
      '/assets/images/kornish/kornish2.jpeg', '/assets/images/kornish/kornish3.jpg', '/assets/images/kornish/kornish5.jpg',
      '/assets/images/kornish/kornish6.jpeg', '/assets/images/kornish/kornish8.jpeg', '/assets/images/kornish/kornish9.png'
    ],
    latitude: 28.1099,
    longitude: 30.7503,
    openingHours: { en: '24 hours', ar: 'على مدار ٢٤ ساعة' },
    ticketPrice: { en: 'Free', ar: 'مجاني' },
    rating: 4.3,
    reviewCount: 89,
    category: { en: 'Scenic Area', ar: 'منطقة طبيعية' },
    features: [
      { en: 'Walking Path', ar: 'ممر مشاة' },
      { en: 'Cafes', ar: 'مقاهي' },
      { en: 'Boat Rides', ar: 'نزهات بالقوارب' },
      { en: 'Photography Spots', ar: 'أماكن للتصوير' }
    ],
    significance: {
      en: 'Modern recreational area showcasing the beauty of the Nile River',
      ar: 'منطقة ترفيهية حديثة تُبرز جمال نهر النيل'
    },
    bookingUrl: null
  },
  {
    id: '5',
    name: { en: "Fraser's Graves", ar: 'مقابر فريزر' },
    description: {
      en: 'The Fraser Tombs are located on a small hillside at the base of the Eastern Desert cliffs, about 10 km northeast of Minya (near Tihna el-Gebel)...',
      ar: 'تقع مقابر فريزر على منحدر تل صغير عند قاعدة منحدرات الصحراء الشرقية على بعد حوالي 10 كيلومترات شمال شرق المنيا...'
    },
    imageUrl: '/assets/images/freezer/freezer.jpg',
    imageGallery: [
      '/assets/images/freezer/freezer.jpg', '/assets/images/freezer/freezer1.jpg', '/assets/images/freezer/freezer2.jpg',
      '/assets/images/freezer/freezer3.jpg', '/assets/images/freezer/freezer4.jpg', '/assets/images/freezer/freezer5.jpg',
      '/assets/images/freezer/freezer6.jpg'
    ],
    latitude: 28.157167,
    longitude: 30.768333,
    openingHours: { en: 'Varies; typically 8:00 AM - 5:00 PM (approx.)', ar: 'تختلف؛ عادةً ٨:٠٠ ص - ٥:٠٠ م (تقريبي)' },
    ticketPrice: { en: 'No official entrance fee listed (generally free / check locally)', ar: 'لا توجد رسوم دخول رسمية مُعلنة (مجاني غالبًا - يُرجى التأكد محليًا)' },
    rating: 4.1,
    reviewCount: 13,
    category: { en: 'Historical Site', ar: 'موقع تاريخي' },
    features: [
      { en: 'Walking Path / Hill climb', ar: 'ممر مشي / صعود تل' },
      { en: 'Guided Tours (available locally)', ar: 'جولات مع مرشد (متوفرة محليًا)' },
      { en: 'Viewing / Panorama point', ar: 'نقطة مشاهدة / بانوراما' },
      { en: 'Photography spots', ar: 'أماكن للتصوير' }
    ],
    significance: {
      en: 'An Old Kingdom necropolis of rock-cut mastaba-style tombs notable for their architecture, statues and inscriptions...',
      ar: 'مقبرة من عصر الدولة القديمة تضم مصاطب ومقابر محفورة في الصخر...'
    },
    bookingUrl: 'https://egymonuments.com/details/FraserTombs'
  },
  {
    id: '6',
    name: { en: "Sultan's Corner / Zawyet Sultan", ar: 'زاوية سلطان' },
    description: {
      en: "Sultan's Corner (also known as the Cemetery of the Dead, Zawyet Sultan) is located on the east bank of the Nile near the city of Minya...",
      ar: 'زاوية سلطان (المعروفة أيضًا بمقبرة الأموات أو زاوية الأموات) تقع على الضفة الشرقية للنيل قرب مدينة المنيا...'
    },
    imageUrl: '/assets/images/zawya/zawya1.jpg',
    imageGallery: ['/assets/images/zawya/zawya.jpg', '/assets/images/zawya/zawya1.jpg', '/assets/images/zawya/zawya2.jpg'],
    latitude: 28.065362,
    longitude: 30.814967,
    openingHours: { en: 'No official hours publicized; access typically daytime', ar: 'لا توجد ساعات رسمية معلنة؛ الدخول غالباً أثناء النهار' },
    ticketPrice: { en: 'Free (no official fee known)', ar: 'مجاني (لا توجد رسوم رسمية معروفة)' },
    rating: 0,
    reviewCount: 0,
    category: { en: 'Islamic Religious Site', ar: 'موقع ديني اسلامي' },
    features: [
      { en: 'Mausoleums and Family Tombs', ar: 'مقابر عائلية وأضرحة' },
      { en: 'Shrines of Saints', ar: 'أضرحة الأولياء' },
      { en: 'Decorative Architecture and Wall Art', ar: 'عمارة زخرفية وفن جداري' },
      { en: 'Pilgrimage / Religious Visits', ar: 'زيارات دينية / تبرك' }
    ],
    significance: {
      en: 'An important cultural-religious cemetery combining Islamic funerary architecture, local religious traditions...',
      ar: 'مقبرة/زاوية تجمع بين العمارة الجنائزية الإسلامية، التقاليد الدينية المحلية...'
    },
    bookingUrl: 'https://egymonuments.com/details/ZawyetSultan'
  },
  {
    id: '7',
    name: { en: 'Mallawy Museum', ar: 'متحف ملوي' },
    description: {
      en: 'The Mallawi Museum is one of the most important regional museums in Upper Egypt, narrating the history of Mallawi...',
      ar: 'يُعد متحف ملوي أحد أهم المتاحف الإقليمية في صعيد مصر، يروي تاريخ مدينة ملوي...'
    },
    imageUrl: '/assets/images/mthaf/mat7af.jpg',
    imageGallery: [
      '/assets/images/mthaf/mat7af.jpg', '/assets/images/mthaf/mat7af1.jpg', '/assets/images/mthaf/mat7af2.jpg',
      '/assets/images/mthaf/mat7af3.jpg', '/assets/images/mthaf/mat7af4.jpg', '/assets/images/mthaf/mat7af5.jpg',
      '/assets/images/mthaf/mat7af6.jpg', '/assets/images/mthaf/mat7af7.jpg', '/assets/images/mthaf/mat7af8.jpg',
      '/assets/images/mthaf/mat7af9.jpg', '/assets/images/mthaf/mat7af10.jpg', '/assets/images/mthaf/mat7af11.jpg',
      '/assets/images/mthaf/mat7af12.jpg', '/assets/images/mthaf/mat7af13.jpg', '/assets/images/mthaf/mat7af14.jpg',
      '/assets/images/mthaf/mat7af15.jpg', '/assets/images/mthaf/mat7af16.jpg'
    ],
    latitude: 27.735808,
    longitude: 30.844428,
    openingHours: { en: '9:00 AM - 5:00 PM daily', ar: '٩:٠٠ ص - ٥:٠٠ م يوميًا' },
    ticketPrice: { en: 'EGP 20 for Egyptians / EGP 100 for foreigners', ar: '٢٠ جنيهًا للمصريين / ١٠٠ جنيه للأجانب' },
    rating: 4.4,
    reviewCount: 87,
    category: { en: 'Museum', ar: 'متحف' },
    features: [
      { en: 'Ancient Artifacts and Statues', ar: 'قطع أثرية وتماثيل قديمة' },
      { en: 'Pharaonic, Greek, Roman, and Coptic Collections', ar: 'مجموعات فرعونية ويونانية ورومانية وقبطية' },
      { en: 'Educational and Cultural Exhibits', ar: 'معارض تعليمية وثقافية' },
      { en: 'Restored Historical Displays', ar: 'معروضات تاريخية مُرمّمة' }
    ],
    significance: {
      en: 'A key cultural institution preserving Upper Egypt’s heritage, showcasing artifacts from Minya’s archaeological sites...',
      ar: 'مؤسسة ثقافية رئيسية تحفظ تراث صعيد مصر، وتعرض آثارًا من مواقع محافظة المنيا...'
    },
    bookingUrl: null
  },
  {
    id: '8',
    name: { en: 'El Ashmunein / Hermopolis', ar: 'الأشمونيْن / هيرمُوبوليس' },
    description: {
      en: 'El Ashmunein, known in ancient times as Hermopolis Magna (Khmunu), is a major archaeological site on the west bank of the Nile...',
      ar: 'الأشمونيْن، المعروفة في العصور القديمة بهيرموبوليس ماجنا (خمنو)، هي موقع أثري كبير على الضفة الغربية للنيل...'
    },
    imageUrl: '/assets/images/ashmunin/ashmunin_main.jpg',
    imageGallery: [
      '/assets/images/ashmunin/ashmunin_main.jpg', '/assets/images/ashmunin/ashmunin1.jpg',
      '/assets/images/ashmunin/ashmunin2.jpg', '/assets/images/ashmunin/ashmunin3.jpg'
    ],
    latitude: 27.781394,
    longitude: 30.801710,
    openingHours: { en: 'Approximately 8:00 AM – 5:00 PM (daytime access)', ar: 'تقريبًا من ٨:٠٠ ص إلى ٥:٠٠ م (الوصول خلال ساعات النهار)' },
    ticketPrice: { en: 'EGP 35 (estimated for foreigners, lower for Egyptians)', ar: 'حوالي ٣٥ جنيه للأجانب، أقل للمصريين' },
    rating: 3.7,
    reviewCount: 15,
    category: { en: 'Historical Site', ar: 'موقع أثري ' },
    features: [
      { en: 'Temple ruins of Thoth / Colonnades', ar: 'أطلال معبد تحوت / أعمدة' },
      { en: 'Open-air museum & artifacts', ar: 'متحف في الهواء الطلق وقطع أثرية' },
      { en: 'Roman Agora & Basilica remains', ar: 'أغورا رومانية وبقايا بازيليكا' },
      { en: 'Colossal baboon statues', ar: 'تماثيل ضخمة لبَابون (تحوت)' }
    ],
    significance: {
      en: 'El Ashmunein is a cultural-religious site marking the importance of Thoth worship, the evolution of Egyptian urban and religious life...',
      ar: 'الأشمونيْن موقع ذو أهمية ثقافية ودينية يُعبّر عن عبادة تحوت، وتطوّر الحياة الحضرية والدينية المصرية...'
    },
    bookingUrl: null
  },
  {
    id: '9',
    name: { en: 'Deir el-Bersha', ar: 'دير البرشا' },
    description: {
      en: 'Deir el-Bersha is one of the most important archaeological sites in Minya Governorate, located on the east bank of the Nile opposite Mallawi...',
      ar: 'تُعد منطقة دير البرشا من أهم وأغنى المواقع الأثرية في محافظة المنيا، وتقع على الضفة الشرقية لنهر النيل أمام مدينة ملوي...'
    },
    imageUrl: '/assets/images/dirElbarsha/direlbarsha4.png',
    imageGallery: [
      '/assets/images/dirElbarsha/direlbarsha4.png', '/assets/images/dirElbarsha/dirElbarsha.png',
      '/assets/images/dirElbarsha/direlbarsga1.png', '/assets/images/dirElbarsha/direlbarsha2.png'
    ],
    latitude: 27.73,
    longitude: 30.9,
    openingHours: { en: '8:00 AM - 4:00 PM', ar: '٨:٠٠ ص - ٤:٠٠ م' },
    ticketPrice: { en: '80 EGP', ar: '٨٠ جنيه' },
    rating: 4.7,
    reviewCount: 256,
    category: { en: 'Archaeological Site', ar: 'موقع أثري' },
    features: [
      { en: 'Rock-Cut Tombs of Middle Kingdom Officials', ar: 'مقابر منحوتة في الصخر لحكام الدولة الوسطى' },
      { en: 'Famous Tomb of Djehutyhotep', ar: 'مقبرة دجحوتي حتب الشهيرة' },
      { en: 'Colorful Wall Paintings and Hieroglyphic Inscriptions', ar: 'نقوش جدارية ملونة ونصوص هيروغليفية' },
      { en: 'Panoramic Desert View and Monastic Heritage', ar: 'إطلالة جبلية بانورامية وتراث ديني مسيحي' }
    ],
    historicalPeriod: { en: 'Middle Kingdom (c. 2000 BC)', ar: 'عصر الدولة الوسطى (حوالي ٢٠٠٠ قبل الميلاد)' },
    significance: {
      en: 'One of the richest Middle Kingdom necropolises in Egypt, combining ancient Egyptian art and Christian monastic heritage.',
      ar: 'من أغنى جبانات الدولة الوسطى في مصر، تجمع بين فنون مصر القديمة والتراث المسيحي في الصعيد.'
    },
    bookingUrl: null
  },
  {
    id: '10',
    name: { en: 'Sheikh Abada (Antinopolis)', ar: 'الشيخ عبادة (أنطينوبوليس)' },
    description: {
      en: 'Located on the eastern bank of the Nile opposite Mallawi, Sheikh Abada—known in antiquity as Antinopolis—was founded by Emperor Hadrian around 130 AD...',
      ar: 'تقع منطقة الشيخ عبادة على الضفة الشرقية لنهر النيل في مواجهة مدينة ملوي، وكانت تعرف في العصور القديمة باسم "أنطينوبوليس"...'
    },
    imageUrl: '/assets/images/ebadah/ebadah.jpg',
    imageGallery: [
      '/assets/images/ebadah/ebadah.jpg', '/assets/images/ebadah/ebadah1.jpg', '/assets/images/ebadah/ebadah2.jpg',
      '/assets/images/ebadah/ebadah3.jpg', '/assets/images/ebadah/ebadah4.jpg'
    ],
    latitude: 27.737222,
    longitude: 30.903611,
    openingHours: { en: '8:00 AM - 4:00 PM', ar: '٨:٠٠ ص - ٤:٠٠ م' },
    ticketPrice: { en: '60 EGP', ar: '٦٠ جنيه' },
    rating: 4.3,
    reviewCount: 42,
    category: { en: 'Archaeological Site', ar: 'موقع أثري' },
    features: [
      { en: 'Greco-Roman ruins', ar: 'آثار يونانية رومانية' },
      { en: 'Ancient temples and baths', ar: 'معابد وحمامات أثرية' },
      { en: 'Coptic monasteries and churches', ar: 'أديرة وكنائس قبطية' },
      { en: 'Islamic shrine of Sheikh Abada', ar: 'ضريح الشيخ عبادة' },
      { en: 'Photography spots', ar: 'أماكن للتصوير' }
    ],
    historicalPeriod: { en: 'Roman Period (Founded c. 130 AD)', ar: 'العصر الروماني (تأسست حوالي عام ١٣٠م)' },
    significance: {
      en: 'A major archaeological site representing the Roman city of Antinopolis, showcasing a unique blend of Roman urban planning, Coptic heritage, and Islamic spirituality.',
      ar: 'موقع أثري بارز يمثل مدينة أنطينوبوليس الرومانية ويُظهر مزيجًا فريدًا من التخطيط الحضري الروماني والتراث القبطي والروحانية الإسلامية.'
    },
    bookingUrl: null
  },
  {
    id: '11',
    name: { en: 'Deir Abu Hinnis', ar: 'دير أبوحنس' },
    description: {
      en: 'Located on the eastern bank of the Nile near Mallawi in Minya Governorate, Deir Abu Hinnis is one of the most important Coptic archaeological areas in Upper Egypt...',
      ar: 'تقع منطقة دير أبوحنس على الضفة الشرقية لنهر النيل بالقرب من مدينة ملوي بمحافظة المنيا، وتُعد من أهم المناطق القبطية الأثرية في صعيد مصر...'
    },
    imageUrl: '/assets/images/dirAbohenes/dirAbohenes.jpg',
    imageGallery: ['/assets/images/dirAbohenes/dirAbohenes.jpg', '/assets/images/dirAbohenes/dirAbohenes1.jpg', '/assets/images/dirAbohenes/dirAbohenes2.png'],
    latitude: 28.091698,
    longitude: 30.753112,
    openingHours: { en: '8:00 AM - 4:00 PM', ar: '٨:٠٠ ص - ٤:٠٠ م' },
    ticketPrice: { en: 'Free Entry', ar: 'دخول مجاني' },
    rating: 4.7,
    reviewCount: 128,
    category: { en: 'Christian religious site', ar: 'موقع ديني مسيحي' },
    features: [
      { en: 'Rock-cut churches and monasteries', ar: 'كنائس وأديرة منحوتة في الصخر' },
      { en: 'Coptic art and inscriptions', ar: 'فن ونقوش قبطية' },
      { en: 'Part of the Holy Family Route', ar: 'جزء من مسار العائلة المقدسة' },
      { en: 'Panoramic Nile view', ar: 'إطلالة بانورامية على النيل' },
      { en: 'Pilgrimage destination', ar: 'وجهة للحجاج والزوار' }
    ],
    historicalPeriod: { en: 'Early Christian Period (4th–5th centuries AD)', ar: 'العصر المسيحي المبكر (القرنان الرابع والخامس الميلاديان)' },
    significance: {
      en: 'A significant Coptic site featuring early Christian rock-cut architecture and one of the stations of the Holy Family in Egypt.',
      ar: 'موقع قبطي هام يضم عمارة مسيحية منحوتة في الصخر ويُعد إحدى محطات العائلة المقدسة في مصر.'
    },
    bookingUrl: null
  },
  {
    id: '12',
    name: { en: 'Al-Asqalani Mosque', ar: 'مسجد العسقلاني' },
    description: {
      en: 'Al-Asqalani Mosque, founded in 1193 AH (1779 AD), is one of the most prominent historical mosques in Minya Governorate...',
      ar: 'يُعد مسجد العسقلاني من أقدم وأشهر المساجد الأثرية بمحافظة المنيا، حيث أُنشئ عام 1193 هـ (1779 م) في أواخر العصر العثماني...'
    },
    imageUrl: '/assets/images/3skalany/3skalany.jpg',
    imageGallery: ['/assets/images/3skalany/3skalany.jpg', '/assets/images/3skalany/3skalany1.jpg', '/assets/images/3skalany/3skalany2.jpg', '/assets/images/3skalany/3skalany3.jpg'],
    latitude: 28.0835,
    longitude: 30.7601,
    openingHours: { en: 'Open daily; typically during prayer times', ar: 'مفتوح يومياً؛ عادةً خلال أوقات الصلاة' },
    ticketPrice: { en: 'Free Entry', ar: 'دخول مجاني' },
    rating: 4.6,
    reviewCount: 97,
    category: { en: 'Islamic Religious Site', ar: 'موقع ديني اسلامي' },
    features: [
      { en: 'Ottoman architectural style', ar: 'طراز معماري عثماني' },
      { en: 'Central dome and minaret', ar: 'قبة مركزية ومئذنة شامخة' },
      { en: 'Shrine of Sheikh Al-Asqalani', ar: 'ضريح الشيخ العسقلاني' },
      { en: 'Sufi gatherings and Quran recitation', ar: 'حلقات صوفية وتلاوة القرآن' },
      { en: 'Heritage site and photography spot', ar: 'موقع تراثي وأماكن للتصوير' }
    ],
    historicalPeriod: { en: 'Ottoman Period (18th century AD)', ar: 'العصر العثماني (القرن الثامن عشر الميلادي)' },
    significance: {
      en: 'A distinguished Ottoman-era mosque reflecting Islamic art, local craftsmanship, and the enduring spiritual heritage of Minya.',
      ar: 'مسجد أثري مميز من العصر العثماني يعكس روعة الفن الإسلامي والحرفية المحلية والتراث الروحي لمحافظة المنيا.'
    },
    bookingUrl: null
  },
  {
    id: '13',
    name: { en: 'Al-Yousifi Mosque', ar: 'مسجد اليوسفي' },
    description: {
      en: 'Al-Yousifi Mosque, located in Minya Governorate, dates back to the Fatimid era (11th century AD)...',
      ar: 'يُعد مسجد اليوسفي من أبرز المعالم الأثرية في محافظة المنيا، ويرجع تاريخه إلى العصر الفاطمي...'
    },
    imageUrl: '/assets/images/yousfy/yousfy.jpg',
    imageGallery: [
      '/assets/images/yousfy/yousfy.jpg', '/assets/images/yousfy/yousfy1.jpg', '/assets/images/yousfy/yousfy2.jpg',
      '/assets/images/yousfy/yousfy3.jpg', '/assets/images/yousfy/yousfy4.jpg', '/assets/images/yousfy/yousfy5.jpg',
      '/assets/images/yousfy/yousfy6.jpg', '/assets/images/yousfy/yousfy7.jpg', '/assets/images/yousfy/yousfy8.jpg',
      '/assets/images/yousfy/yousfy9.jpg'
    ],
    latitude: 28.0872,
    longitude: 30.7503,
    openingHours: { en: 'Open daily; typically during prayer times', ar: 'مفتوح يوميًا؛ عادةً خلال أوقات الصلاة' },
    ticketPrice: { en: 'Free Entry', ar: 'دخول مجاني' },
    rating: 4.7,
    reviewCount: 83,
    category: { en: 'Islamic Religious Site', ar: 'موقع ديني اسلامي' },
    features: [
      { en: 'Fatimid architectural style', ar: 'طراز معماري فاطمي' },
      { en: 'Decorated mihrab and pointed arches', ar: 'محراب مزخرف وأقواس مدببة' },
      { en: 'Historical minaret of Fatimid design', ar: 'مئذنة أثرية على الطراز الفاطمي' },
      { en: 'Spiritual and cultural heritage site', ar: 'موقع تراثي ديني وثقافي' },
      { en: 'Stone carvings and geometric patterns', ar: 'نقوش حجرية وزخارف هندسية' }
    ],
    historicalPeriod: { en: 'Fatimid Period (11th century AD)', ar: 'العصر الفاطمي (القرن الحادي عشر الميلادي)' },
    significance: {
      en: 'A remarkable Fatimid-era mosque symbolizing the early Islamic architectural identity and cultural richness of Minya.',
      ar: 'مسجد أثري مميز من العصر الفاطمي يجسد الهوية المعمارية الإسلامية المبكرة وغنى التراث الثقافي لمحافظة المنيا.'
    },
    bookingUrl: null
  },
  {
    id: '14',
    name: { en: 'Istabl Antar', ar: 'إسطبل عنتر' },
    description: {
      en: 'Istabl Antar, located on the eastern bank of the Nile near Abu Qurqas in Minya Governorate, is one of the most significant archaeological sites in Middle Egypt...',
      ar: 'تقع منطقة إسطبل عنتر على الضفة الشرقية لنهر النيل بالقرب من مركز أبو قرقاص بمحافظة المنيا، وتُعد من أهم المناطق الأثرية في مصر الوسطى...'
    },
    imageUrl: '/assets/images/istablantar/istablantar.jpg',
    imageGallery: [
      '/assets/images/istablantar/istablantar.jpg', '/assets/images/istablantar/istablantar1.jpg', '/assets/images/istablantar/istablantar2.jpg',
      '/assets/images/istablantar/istablantar3.jpg', '/assets/images/istablantar/istablantar4.jpg', '/assets/images/istablantar/istablantar5.jpg'
    ],
    latitude: 27.9312,
    longitude: 30.8495,
    openingHours: { en: '8:00 AM - 5:00 PM', ar: '٨:٠٠ ص - ٥:٠٠ م' },
    ticketPrice: { en: 'EGP 60 for foreigners, EGP 20 for Egyptians', ar: '٦٠ جنيه للأجانب، ٢٠ جنيه للمصريين' },
    rating: 4.8,
    reviewCount: 142,
    category: { en: 'Archaeological Site', ar: 'موقع أثري' },
    features: [
      { en: 'Rock-cut tombs of the Middle Kingdom', ar: 'مقابر منحوتة في الصخر من الدولة الوسطى' },
      { en: 'Khnumhotep II tomb with colorful scenes', ar: 'مقبرة خنوم حتب الثاني ذات المناظر الملونة' },
      { en: 'Panoramic view of the Nile Valley', ar: 'إطلالة بانورامية على وادي النيل' },
      { en: 'Pharaonic and Coptic remains', ar: 'آثار فرعونية وقبطية' },
      { en: 'Research and photography destination', ar: 'وجهة للبحث والتصوير الأثري' }
    ],
    historicalPeriod: { en: 'Old and Middle Kingdoms (c. 2300–1800 BC)', ar: 'عصري الدولة القديمة والوسطى (حوالي 2300–1800 ق.م)' },
    significance: {
      en: 'An archaeological treasure housing the tombs of ancient governors and offering vivid depictions of life in Pharaonic Egypt.',
      ar: 'كنز أثري يضم مقابر حكام قدماء ومشاهد ملونة تجسد تفاصيل الحياة في مصر الفرعونية.'
    },
    bookingUrl: null
  },
  {
    id: '15',
    name: { en: 'Tihna El-Gebel', ar: 'طهنا الجبل' },
    description: {
      en: 'Tihna El-Gebel, located on the eastern bank of the Nile opposite Minya City, is one of the most remarkable archaeological sites in Middle Egypt...',
      ar: 'تقع منطقة طهنا الجبل على الضفة الشرقية لنهر النيل في مواجهة مدينة المنيا، وتُعد من أبرز المناطق الأثرية في مصر الوسطى...'
    },
    imageUrl: '/assets/images/tihna/tihna.jpg',
    imageGallery: [
      '/assets/images/tihna/tihna.jpg', '/assets/images/tihna/tihna1.jpg', '/assets/images/tihna/tihna2.jpg',
      '/assets/images/tihna/tihna3.jpg', '/assets/images/tihna/tihna4.jpg', '/assets/images/tihna/tihna5.jpg'
    ],
    latitude: 28.1336,
    longitude: 30.7991,
    openingHours: { en: '8:00 AM - 5:00 PM', ar: '٨:٠٠ ص - ٥:٠٠ م' },
    ticketPrice: { en: 'EGP 60 for foreigners, EGP 20 for Egyptians', ar: '٦٠ جنيه للأجانب، ٢٠ جنيه للمصريين' },
    rating: 4.7,
    reviewCount: 118,
    category: { en: 'Archaeological Site', ar: 'موقع أثري' },
    features: [
      { en: 'Rock-cut tombs and temples', ar: 'مقابر ومعابد منحوتة في الصخر' },
      { en: 'Temple of Petosiris', ar: 'معبد بتوزيريس' },
      { en: 'Pharaonic, Greco-Roman, and Coptic remains', ar: 'آثار فرعونية ويونانية رومانية وقبطية' },
      { en: 'Cliffside hermit chapels', ar: 'كنائس صخرية للرهبان الأوائل' },
      { en: 'Panoramic Nile view', ar: 'إطلالة بانورامية على النيل' }
    ],
    historicalPeriod: { en: 'Old Kingdom to Coptic Period (c. 2500 BC – 5th century AD)', ar: 'من عصر الدولة القديمة حتى العصر القبطي (حوالي ٢٥٠٠ ق.م – القرن الخامس الميلادي)' },
    significance: {
      en: 'A multi-period archaeological site illustrating Egypt’s religious and cultural continuity from Pharaonic through Coptic times.',
      ar: 'موقع أثري متعدد العصور يعكس استمرارية الدين والثقافة في مصر من العصر الفرعوني حتى القبطي.'
    },
    bookingUrl: null
  },
  {
    id: '16',
    name: { en: 'Al-Wadaa Al-Omrawi Mosque', ar: 'مسجد الوداع العمراوي' },
    description: {
      en: 'Al-Wadaa Al-Omrawi Mosque, located in the heart of Minya City, is one of the most renowned historical mosques in Upper Egypt...',
      ar: 'يقع مسجد الوداع العمراوي في قلب مدينة المنيا، ويُعد من أشهر المساجد التاريخية في صعيد مصر...'
    },
    imageUrl: '/assets/images/wadaa/wadaa.jpg',
    imageGallery: [
      '/assets/images/wadaa/wadaa.jpg', '/assets/images/wadaa/wadaa1.jpg', '/assets/images/wadaa/wadaa2.jpg',
      '/assets/images/wadaa/wadaa3.jpg', '/assets/images/wadaa/wadaa7.jpg', '/assets/images/wadaa/wadaa8.jpg',
      '/assets/images/wadaa/wadaa9.jpg', '/assets/images/wadaa/wadaa10.jpg', '/assets/images/wadaa/wadaa4.jpg',
      '/assets/images/wadaa/wadaa5.jpg', '/assets/images/wadaa/wadaa6.jpg'
    ],
    latitude: 28.0948,
    longitude: 30.7509,
    openingHours: { en: 'Open daily; mainly during prayer times', ar: 'مفتوح يوميًا؛ بشكل أساسي خلال أوقات الصلاة' },
    ticketPrice: { en: 'Free Entry', ar: 'دخول مجاني' },
    rating: 4.8,
    reviewCount: 102,
    category: { en: 'Islamic Religious Site', ar: 'موقع ديني اسلامي' },
    features: [
      { en: 'Ottoman-style dome and arches', ar: 'قبة وأقواس على الطراز العثماني' },
      { en: 'Wooden minbar and ornate mihrab', ar: 'منبر خشبي ومحراب مزخرف' },
      { en: 'Sufi gatherings and Quranic education', ar: 'حلقات صوفية وتعليم القرآن' },
      { en: 'Spiritual atmosphere', ar: 'أجواء روحانية هادئة' },
      { en: 'Historic architecture and heritage site', ar: 'عمارة تاريخية وموقع تراثي' }
    ],
    historicalPeriod: { en: 'Ottoman Period (18th–19th century AD)', ar: 'العصر العثماني (القرن الثامن عشر – التاسع عشر الميلادي)' },
    significance: {
      en: 'A spiritual and historical landmark in Minya representing Ottoman religious architecture and Sufi tradition.',
      ar: 'مَعْلَم ديني وتاريخي يعكس العمارة العثمانية الدينية والتقاليد الصوفية في المنيا.'
    },
    bookingUrl: null
  },
  {
    id: '17',
    name: { en: 'Al-Lamty Mosque', ar: 'مسجد اللمطي' },
    description: {
      en: 'Al-Lamty Mosque, located in the city of Minya, is one of the most remarkable historical mosques in Upper Egypt...',
      ar: 'يقع مسجد اللمطي في مدينة المنيا، ويُعد من أبرز المساجد التاريخية في صعيد مصر...'
    },
    imageUrl: '/assets/images/lamty/lamty.png',
    imageGallery: [
      '/assets/images/lamty/lamty.png', '/assets/images/lamty/lamty1.jpg', '/assets/images/lamty/lamty2.jpeg',
      '/assets/images/lamty/lamty3.jpeg', '/assets/images/lamty/lamty4.png', '/assets/images/lamty/lamty5.png',
      '/assets/images/lamty/lamty6.jpg'
    ],
    latitude: 28.0985,
    longitude: 30.7501,
    openingHours: { en: 'Open daily; mainly during prayer times', ar: 'مفتوح يوميًا؛ بشكل أساسي خلال أوقات الصلاة' },
    ticketPrice: { en: 'Free Entry', ar: 'دخول مجاني' },
    rating: 4.6,
    reviewCount: 132,
    category: { en: 'Islamic Religious Site', ar: 'موقع ديني اسلامي' },
    features: [
      { en: 'Ottoman-style dome and arches', ar: 'قبة وأقواس على الطراز العثماني' },
      { en: 'Wooden minbar and ornate mihrab', ar: 'منبر خشبي ومحراب مزخرف' },
      { en: 'Quranic study and Sufi gatherings', ar: 'تعليم قرآني وحلقات صوفية' },
      { en: 'Spiritual and peaceful atmosphere', ar: 'أجواء روحانية هادئة' },
      { en: 'Historic architecture and cultural heritage', ar: 'عمارة تاريخية وتراث ثقافي' }
    ],
    historicalPeriod: { en: 'Ottoman Period (18th century AD)', ar: 'العصر العثماني (القرن الثامن عشر الميلادي)' },
    significance: {
      en: 'A historical Ottoman mosque representing faith, art, and spirituality in Minya.',
      ar: 'مسجد عثماني تاريخي يعكس الإيمان والفن والروحانية في مدينة المنيا.'
    },
    bookingUrl: null
  },
  {
    id: '18',
    name: { en: 'Al-Foli Mosque', ar: 'مسجد الفولي' },
    description: {
      en: 'Al-Foli Mosque is one of the most significant and beloved religious landmarks in Minya City...',
      ar: 'يُعد مسجد الفولي من أبرز وأحب المعالم الدينية في مدينة المنيا...'
    },
    imageUrl: '/assets/images/foli/main.jpg',
    imageGallery: [
      '/assets/images/foli/foli.jpg', '/assets/images/foli/foli1.jpeg', '/assets/images/foli/foli2.png',
      '/assets/images/foli/foli3.png', '/assets/images/foli/foli4.png', '/assets/images/foli/foli5.jpg'
    ],
    latitude: 28.0873,
    longitude: 30.7541,
    openingHours: { en: 'Open daily; mainly during prayer times', ar: 'مفتوح يوميًا؛ بشكل أساسي خلال أوقات الصلاة' },
    ticketPrice: { en: 'Free Entry', ar: 'دخول مجاني' },
    rating: 4.9,
    reviewCount: 178,
    category: { en: 'Islamic Religious Site', ar: 'موقع ديني اسلامي' },
    features: [
      { en: 'Blend of Ottoman and Mamluk architecture', ar: 'مزيج من العمارة العثمانية والمملوكية' },
      { en: 'Tomb of Sheikh Ahmed Al-Foli', ar: 'ضريح الشيخ أحمد الفولي' },
      { en: 'Sufi gatherings and Quranic study', ar: 'حلقات صوفية وتعليم القرآن' },
      { en: 'Annual Mawlid celebrations', ar: 'احتفالات المولد السنوية' },
      { en: 'Spiritual and cultural heritage site', ar: 'موقع تراثي روحي وثقافي' }
    ],
    historicalPeriod: { en: 'Ottoman Period (18th–19th century AD)', ar: 'العصر العثماني (القرن الثامن عشر – التاسع عشر الميلادي)' },
    significance: {
      en: 'A major religious and cultural landmark in Minya, representing the legacy of Sheikh Ahmed Al-Foli and the city’s Sufi traditions.',
      ar: 'مَعْلَم ديني وثقافي بارز في المنيا يعكس إرث الشيخ أحمد الفولي والتقاليد الصوفية في المدينة.'
    },
    bookingUrl: null
  },
  {
    id: '19',
    name: { en: 'Ali Shaarawy Mosque', ar: 'مسجد علي شعراوي' },
    description: {
      en: 'Ali Shaarawy Mosque is one of the most distinguished modern Islamic landmarks in Minya Governorate...',
      ar: 'يُعد مسجد علي شعراوي من أبرز المعالم الإسلامية الحديثة في محافظة المنيا...'
    },
    imageUrl: '/assets/images/shaarawy/shaarawy.jpg',
    imageGallery: [
      '/assets/images/shaarawy/shaarawy.jpg', '/assets/images/shaarawy/shaarawy1.jpg', '/assets/images/shaarawy/shaarawy2.jpeg',
      '/assets/images/shaarawy/shaarawy3.jpeg', '/assets/images/shaarawy/shaarawy4.jpeg', '/assets/images/shaarawy/shaarawy5.png'
    ],
    latitude: 28.0926,
    longitude: 30.7494,
    openingHours: { en: 'Open daily; during all prayer times', ar: 'مفتوح يوميًا خلال جميع أوقات الصلاة' },
    ticketPrice: { en: 'Free Entry', ar: 'دخول مجاني' },
    rating: 4.7,
    reviewCount: 143,
    category: { en: 'Islamic Religious Site', ar: 'موقع ديني اسلامي' },
    features: [
      { en: 'Neo-Islamic and Ottoman-inspired architecture', ar: 'عمارة إسلامية حديثة بتأثير عثماني' },
      { en: 'Elegant dome and tall minaret', ar: 'قبة أنيقة ومئذنة شامخة' },
      { en: 'Spacious prayer hall', ar: 'قاعة صلاة واسعة' },
      { en: 'Cultural and religious activities', ar: 'أنشطة دينية وثقافية' },
      { en: 'Central landmark in Minya City', ar: 'مَعْلَم مركزي في مدينة المنيا' }
    ],
    historicalPeriod: { en: 'Modern Islamic Architecture (Early 20th century)', ar: 'العمارة الإسلامية الحديثة (بداية القرن العشرين)' },
    significance: {
      en: 'A central mosque symbolizing Minya’s modern Islamic identity and its historical continuity of faith and culture.',
      ar: 'مسجد مركزي يرمز لهوية المنيا الإسلامية الحديثة واستمرارية تراثها الديني والثقافي.'
    },
    bookingUrl: null
  },
  {
    id: '20',
    name: { en: 'Anba Bahur Church', ar: 'كنيسة الأنبا باهور' },
    description: {
      en: 'Anba Bahur Church, located in Minya Governorate, is one of the significant Coptic Orthodox churches in Upper Egypt...',
      ar: 'تُعد كنيسة الأنبا باهور من الكنائس القبطية الأرثوذكسية البارزة في محافظة المنيا...'
    },
    imageUrl: '/assets/images/bahur/bahur1.jpg',
    imageGallery: [
      '/assets/images/bahur/bahur.jpg', '/assets/images/bahur/bahur1.jpg', '/assets/images/bahur/bahur2.jpg',
      '/assets/images/bahur/bahur3.jpg', '/assets/images/bahur/bahur4.jpeg', '/assets/images/bahur/bahur5.png'
    ],
    latitude: 28.0941,
    longitude: 30.7518,
    openingHours: { en: 'Daily from 7:00 AM - 8:00 PM', ar: 'يوميًا من ٧:٠٠ ص إلى ٨:٠٠ م' },
    ticketPrice: { en: 'Free Entry', ar: 'دخول مجاني' },
    rating: 4.9,
    reviewCount: 157,
    category: { en: 'Christian religious site', ar: 'موقع ديني مسيحي' },
    features: [
      { en: 'Traditional Coptic architecture', ar: 'طراز قبطي تقليدي' },
      { en: 'Hand-painted icons and domes', ar: 'أيقونات وقباب مرسومة يدويًا' },
      { en: 'Peaceful and spiritual atmosphere', ar: 'أجواء روحانية هادئة' },
      { en: 'Center for Coptic community events', ar: 'مركز للفعاليات الكنسية والخدمية' },
      { en: 'Historic and cultural landmark', ar: 'مَعْلَم ديني وثقافي عريق' }
    ],
    historicalPeriod: { en: 'Modern Coptic Period (20th century)', ar: 'العصر القبطي الحديث (القرن العشرون الميلادي)' },
    significance: {
      en: 'A central Coptic Orthodox church symbolizing the enduring faith and cultural richness of Minya’s Christian community.',
      ar: 'كنيسة قبطية أرثوذكسية مركزية تُجسد عمق الإيمان وغنى التراث المسيحي في محافظة المنيا.'
    },
    bookingUrl: null
  },
  {
    id: '21',
    name: { en: 'Monastery of the Virgin Mary (Gabal Al-Tair, Samalut)', ar: 'دير السيدة العذراء بجبل الطير - سمالوط' },
    description: {
      en: 'The Monastery of the Virgin Mary, located at Gabal Al-Tair near Samalut in Minya Governorate, is one of the most sacred Christian pilgrimage sites in Egypt...',
      ar: 'يُعد دير السيدة العذراء بجبل الطير في سمالوط أحد أهم المزارات الدينية المسيحية في مصر...'
    },
    imageUrl: '/assets/images/virginmonastery/virginmonastery.jpg',
    imageGallery: [
      '/assets/images/virginmonastery/virginmonastery.jpg', '/assets/images/virginmonastery/virginmonastery1.jpg',
      '/assets/images/virginmonastery/virginmonastery2.jpg', '/assets/images/virginmonastery/virginmonastery3.jpg',
      '/assets/images/virginmonastery/virginmonastery4.jpg', '/assets/images/virginmonastery/virginmonastery5.jpg',
      '/assets/images/virginmonastery/virginmonastery6.jpg', '/assets/images/virginmonastery/virginmonastery7.jpg',
      '/assets/images/virginmonastery/virginmonastery8.jpg', '/assets/images/virginmonastery/virginmonastery9.jpg',
      '/assets/images/virginmonastery/virginmonastery10.jpg', '/assets/images/virginmonastery/virginmonastery11.jpg',
      '/assets/images/virginmonastery/virginmonastery12.jpg', '/assets/images/virginmonastery/virginmonastery13.jpg',
      '/assets/images/virginmonastery/virginmonastery14.jpg', '/assets/images/virginmonastery/virginmonastery15.jpg'
    ],
    latitude: 28.3336,
    longitude: 30.7331,
    openingHours: { en: 'Daily from 8:00 AM - 6:00 PM', ar: 'يوميًا من ٨:٠٠ ص إلى ٦:٠٠ م' },
    ticketPrice: { en: 'Free Entry', ar: 'دخول مجاني' },
    rating: 4.9,
    reviewCount: 284,
    category: { en: 'Christian religious site', ar: 'موقع ديني مسيحي' },
    features: [
      { en: 'Rock-cut 4th century church', ar: 'كنيسة منحوتة في الجبل تعود للقرن الرابع الميلادي' },
      { en: 'Holy Family pilgrimage site', ar: 'إحدى محطات العائلة المقدسة' },
      { en: 'Ancient Coptic icons and inscriptions', ar: 'أيقونات ونقوش قبطية أثرية' },
      { en: 'Annual Feast of the Virgin celebration', ar: 'احتفال سنوي بعيد السيدة العذراء' },
      { en: 'Panoramic Nile view', ar: 'إطلالة بانورامية على النيل' }
    ],
    historicalPeriod: { en: 'Early Christian Period (4th century AD)', ar: 'العصر المسيحي المبكر (القرن الرابع الميلادي)' },
    significance: {
      en: 'One of Egypt’s most sacred Christian pilgrimage destinations and a major stop on the Holy Family route, blending spirituality, history, and natural beauty.',
      ar: 'من أقدس المزارات المسيحية في مصر وإحدى محطات العائلة المقدسة، يجمع بين القدسية والتاريخ وجمال الطبيعة.'
    },
    bookingUrl: null
  },
  {
    id: '22',
    name: { en: 'Al-Bahnasa (City of Martyrs) - Bani Mazar', ar: 'البهنسا – مدينة الشهداء ببني مزار' },
    description: {
      en: 'Al-Bahnasa, located west of Bani Mazar in Minya Governorate, is one of Egypt’s most historically and spiritually significant cities...',
      ar: 'تُعد البهنسا الواقعة غرب مركز بني مزار بمحافظة المنيا من أعظم المدن تاريخًا وروحانية في مصر...'
    },
    imageUrl: '/assets/images/bahnasa/bahnasa_main.jpeg',
    imageGallery: [
      '/assets/images/bahnasa/bahnasa_main.jpeg', '/assets/images/bahnasa/bahnasa.png', '/assets/images/bahnasa/bahnasa1.jpg',
      '/assets/images/bahnasa/bahnasa2.jpg', '/assets/images/bahnasa/bahnasa3.png', '/assets/images/bahnasa/bahnasa4.png',
      '/assets/images/bahnasa/bahnasa5.jpeg', '/assets/images/bahnasa/bahnasa6.jpg', '/assets/images/bahnasa/bahnasa7.jpg',
      '/assets/images/bahnasa/bahnasa8.jpeg'
    ],
    latitude: 28.5833,
    longitude: 30.6833,
    openingHours: { en: 'Open daily for visitors', ar: 'مفتوحة يوميًا للزوار' },
    ticketPrice: { en: 'Free Entry', ar: 'دخول مجاني' },
    rating: 4.8,
    reviewCount: 317,
    category: { en: 'Islamic Religious Site', ar: 'موقع ديني اسلامي' },
    features: [
      { en: 'Ancient Greek-Roman city ruins (Oxyrhynchus)', ar: 'آثار المدينة اليونانية الرومانية القديمة (أوكسي رينخوس)' },
      { en: 'Islamic conquest battlefield', ar: 'موقع معركة الفتح الإسلامي' },
      { en: 'Tombs of Prophet’s Companions (Sahabah)', ar: 'قبور عدد كبير من صحابة الرسول ﷺ' },
      { en: 'Famous for Oxyrhynchus Papyri', ar: 'اشتهرت بمخطوطات أوكسي رينخوس البردية' },
      { en: 'Religious pilgrimage site', ar: 'مقصد ديني وروحي للزوار' }
    ],
    historicalPeriod: {
      en: 'Ancient Greek-Roman Era to Early Islamic Period (4th century BC – 7th century AD)',
      ar: 'من العصر اليوناني الروماني إلى صدر الإسلام (من القرن الرابع ق.م إلى القرن السابع م)'
    },
    significance: {
      en: 'A city that witnessed the convergence of civilizations and became a sacred burial site for thousands of martyrs...',
      ar: 'مدينة تجمعت فيها حضارات متعددة من اليونانية والرومانية إلى صدر الإسلام...'
    },
    bookingUrl: null
  },
  {
    id: '23',
    name: { en: 'The Aten Museum (Aton Museum) - Minya', ar: 'المتحف الأتوني - المنيا' },
    description: {
      en: 'The Aten Museum, also known as the Aton Museum, is one of Egypt’s most remarkable modern museums, located on the eastern bank of the Nile River in Minya...',
      ar: 'يُعد المتحف الأتوني أحد أهم المعالم الثقافية الحديثة في صعيد مصر، ويقع على الضفة الشرقية لنهر النيل بمدينة المنيا...'
    },
    imageUrl: '/assets/images/atony.jpg',
    imageGallery: ['/assets/images/atony.jpg', '/assets/images/atony1.jpg', '/assets/images/atony2.jpg', '/assets/images/atony3.jpg'],
    latitude: 28.0935,
    longitude: 30.7513,
    openingHours: { en: 'Daily, 9:00 AM – 5:00 PM', ar: 'يوميًا من 9 صباحًا حتى 5 مساءً' },
    ticketPrice: { en: 'EGP 100 for foreigners, EGP 20 for Egyptians', ar: '100 جنيه للأجانب و20 جنيه للمصريين' },
    rating: 4.7,
    reviewCount: 198,
    category: { en: 'Archaeological Museum', ar: 'متحف أثري' },
    features: [
      { en: 'Dedicated to Pharaoh Akhenaten and the Amarna Period', ar: 'مكرس للملك إخناتون وعصر العمارنة' },
      { en: 'Egyptian-German cooperation project', ar: 'مشروع بالتعاون المصري الألماني' },
      { en: 'Displays rare Amarna artifacts', ar: 'يعرض قطعًا أثرية نادرة من العمارنة' },
      { en: 'Located on the Nile in Minya city', ar: 'يقع على ضفة النيل بمدينة المنيا' },
      { en: 'Cultural venue for events and exhibitions', ar: 'مكان ثقافي لإقامة الفعاليات والمعارض' }
    ],
    historicalPeriod: { en: 'Amarna Period (14th century BC)', ar: 'عصر العمارنة (القرن الرابع عشر قبل الميلاد)' },
    significance: {
      en: 'A modern cultural landmark celebrating the legacy of Akhenaten and the Amarna revolution...',
      ar: 'صرح ثقافي حديث يخلد إرث إخناتون وثورته العمارنية...'
    },
    bookingUrl: null
  }
];

function slugifyName(name) {
  const s = typeof name === 'string' ? name : (name && name.en) || '';
  return String(s)
    .toLowerCase()
    .replace(/[\s_]+/g, '-')
    .replace(/[^a-z0-9-]+/g, '')
    .replace(/--+/g, '-')
    .replace(/^-|-$/g, '');
}

const ATTRACTIONS = RAW_ATTRACTIONS.map(a => ({
  ...a,
  bookingUrl: a.bookingUrl || `https://egymonuments.com/details/${slugifyName(a.name)}`
}));

const postData = Buffer.from(JSON.stringify(ATTRACTIONS), 'utf-8');

const options = {
  hostname: 'localhost',
  port: 7123,
  path: '/api/Attractions/bulk',
  method: 'POST',
  rejectUnauthorized: false,
  headers: {
    'Content-Type': 'application/json; charset=utf-8',
    'Content-Length': postData.length
  }
};

console.log(`Starting bulk insertion for ${ATTRACTIONS.length} attractions...`);

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