INSERT INTO "rate" ("UserId", "MovieId", "Rating")
VALUES 
    (1, 23, FLOOR(RANDOM() * 10 + 1)::INT),
    (1, 24, FLOOR(RANDOM() * 10 + 1)::INT),
    (1, 25, FLOOR(RANDOM() * 10 + 1)::INT),
    (1, 26, FLOOR(RANDOM() * 10 + 1)::INT),
    (1, 27, FLOOR(RANDOM() * 10 + 1)::INT),
    (1, 28, FLOOR(RANDOM() * 10 + 1)::INT),
    (1, 29, FLOOR(RANDOM() * 10 + 1)::INT),
    (1, 30, FLOOR(RANDOM() * 10 + 1)::INT),
    (1, 31, FLOOR(RANDOM() * 10 + 1)::INT),
    (1, 32, FLOOR(RANDOM() * 10 + 1)::INT),
    (1, 33, FLOOR(RANDOM() * 10 + 1)::INT),
    (1, 34, FLOOR(RANDOM() * 10 + 1)::INT),
    (1, 35, FLOOR(RANDOM() * 10 + 1)::INT),
    (1, 36, FLOOR(RANDOM() * 10 + 1)::INT),
    (1, 37, FLOOR(RANDOM() * 10 + 1)::INT)
ON CONFLICT ("UserId", "MovieId") DO UPDATE SET
"Rating" = EXCLUDED."Rating";