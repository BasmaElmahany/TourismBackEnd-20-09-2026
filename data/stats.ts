import { TranslationKeys } from '../services/i18n.service';

export interface StatItem {
  labelKey: keyof TranslationKeys; // key to use with i18n.translate
  defaultLabel: string; // fallback label
  value: string; // display value (e.g. "12+", "125K+")
}

export const stats: StatItem[] = [
  { labelKey: 'historicSites', defaultLabel: 'Historic Sites', value: '12+' },
  { labelKey: 'hotels', defaultLabel: 'Hotels', value: '8+' },
  { labelKey: 'restaurants', defaultLabel: 'Restaurants', value: '15+' },
  { labelKey: 'annualVisitors', defaultLabel: 'Annual Visitors', value: '125K+' }
];
