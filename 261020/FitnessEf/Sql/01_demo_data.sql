INSERT INTO clients
(first_name, last_name, birth_date, phone, email, registration_date, status)
VALUES
('Иван',  'Иванов',   DATE '1999-05-10', '79991112233', 'ivan@example.com',  CURRENT_DATE, 'active'),
('Анна',  'Смирнова', DATE '2002-11-08', '79992223344', 'anna@example.com',  CURRENT_DATE, 'active'),
('Пётр',  'Петров',   DATE '1996-01-21', NULL,          NULL,                CURRENT_DATE, 'inactive');