import { Photographer } from '../models/tourism.models';

export const photographers: Photographer[] = [
{
  id: 'ph-photostar-minya',
  name: { en: 'Photostar Studio', ar: 'استوديو فوتوستار' },
  bio: {
    en: 'Professional photo studio in Minya offering portraits, weddings, and commercial photography with creative retouching services.',
    ar: 'استوديو تصوير احترافي بالمنيا يقدم جلسات بورتريه، تصوير أعراس وفعاليات، وتصوير تجاري بخدمات تنقيح احترافية.'
  },
  specialties: [
    { en: 'Studio Portraits', ar: 'بورتريه استوديو' },
    { en: 'Weddings & Events', ar: 'أعراس وفعاليات' },
    { en: 'Commercial / Product', ar: 'تصوير تجاري / منتجات' },
    { en: 'Photo Retouching', ar: 'تنقيح الصور' }
  ],
  imageUrl: '/assets/images/photostar.jpg',
  phone: { en: '+20 86 236 3820', ar: '٠٨٦٢٣٦٣٨٢٠' },
  email: { en: 'info@photostar-minya.com', ar: 'info@photostar-minya.com' },
  social: {
    instagram: 'photostar_gift',
    facebook: 'https://www.facebook.com/people/Photostar-استوديو-فوتوستار/100076251124481/'
  },
  location: {
    latitude: 28.1031,
    longitude: 30.7478,
    address: { en: 'Corniche El-Minya, Minya, Egypt', ar: 'كورنيش المنيا، المنيا، مصر' }
  },

  rating: 4.5
}



,
  {
  id: 'ph-monalisa-minya',
  name: { en: 'Mona Lisa Studio', ar: 'استوديو الموناليزا' },
  bio: {
    en: 'Well-equipped studio in Minya specializing in portraits, family shoots and wedding photography with on-site retouching services.',
    ar: 'استوديو مجهز جيدًا بالمنيا متخصص في البورتريه، جلسات العائلة، وتصوير الأعراس مع خدمات تنقيح الصور داخل الاستوديو.'
  },
  specialties: [
    { en: 'Portraits', ar: 'بورتريه' },
    { en: 'Weddings & Events', ar: 'أعراس وفعاليات' },
    { en: 'Family Photography', ar: 'تصوير عائلي' },
    { en: 'Photo Retouching', ar: 'تنقيح الصور' },
    { en: 'Product Photography', ar: 'تصوير منتجات' }
  ],
  imageUrl: '/assets/images/monaliza.jpg',
  phone: { en: '+012 26414286', ar: '٠١٢٢٦٤١٤٢٨٦' },
  email: { en: 'contact@monalisa-minya.com', ar: 'contact@monalisa-minya.com' },
  social: {
    instagram: 'monalisa_studio_minya',
    facebook: 'monalisa.studio.minya'
  },
  location: {
    latitude: 28.102371091871028, 
    longitude: 30.754860301848673,
    address: { en: 'El-Minya Corniche, Minya, Egypt', ar: 'كورنيش المنيا، المنيا، مصر' }
  },
  rating: 4.6
}

];
