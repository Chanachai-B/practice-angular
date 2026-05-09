export interface PaginatedResult<T> {
  total: number;
  page: number;
  size: number;
  items: T[];
}