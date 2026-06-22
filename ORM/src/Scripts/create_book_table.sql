-- Chạy script này trong Supabase SQL Editor (Dashboard > SQL Editor)
-- Project: test (eoeqtjprmgppivqdaylm)

CREATE TABLE IF NOT EXISTS public."Book" (
    "Id" SERIAL PRIMARY KEY,
    "Name" VARCHAR(255) NOT NULL,
    "Price" NUMERIC(18, 2) NOT NULL
);

INSERT INTO public."Book" ("Name", "Price")
SELECT 'Clean Code', 20.00
WHERE NOT EXISTS (SELECT 1 FROM public."Book" WHERE "Name" = 'Clean Code');

INSERT INTO public."Book" ("Name", "Price")
SELECT 'ASP.NET MVC', 15.00
WHERE NOT EXISTS (SELECT 1 FROM public."Book" WHERE "Name" = 'ASP.NET MVC');

INSERT INTO public."Book" ("Name", "Price")
SELECT 'Design Pattern', 25.00
WHERE NOT EXISTS (SELECT 1 FROM public."Book" WHERE "Name" = 'Design Pattern');
