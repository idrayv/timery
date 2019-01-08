export interface EventsQuery {
  events: CategoryEvent[];
}

export interface CategoryEvent {
  id: number;
  category: Category;
}

export interface Category {
  name: string;
}
