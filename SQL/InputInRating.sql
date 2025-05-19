INSERT INTO "rate" ("UserId", "MovieId", "Rating")
VALUES 
    (1, 4, FLOOR(RANDOM() * 10 + 1)::INT),
    (1, 5, FLOOR(RANDOM() * 10 + 1)::INT),
    (1, 6, FLOOR(RANDOM() * 10 + 1)::INT),
    (1, 7, FLOOR(RANDOM() * 10 + 1)::INT),
    (1, 8, FLOOR(RANDOM() * 10 + 1)::INT),
    (1, 9, FLOOR(RANDOM() * 10 + 1)::INT),
    (1, 10, FLOOR(RANDOM() * 10 + 1)::INT),
    (1, 11, FLOOR(RANDOM() * 10 + 1)::INT),
    (1, 12, FLOOR(RANDOM() * 10 + 1)::INT),
    (1, 13, FLOOR(RANDOM() * 10 + 1)::INT),
    (1, 14, FLOOR(RANDOM() * 10 + 1)::INT),
    (1, 15, FLOOR(RANDOM() * 10 + 1)::INT),
    (1, 16, FLOOR(RANDOM() * 10 + 1)::INT),
    (1, 17, FLOOR(RANDOM() * 10 + 1)::INT),
    (1, 18, FLOOR(RANDOM() * 10 + 1)::INT),
    (1, 25, FLOOR(RANDOM() * 10 + 1)::INT)
ON CONFLICT ("UserId", "MovieId") DO UPDATE SET
"Rating" = EXCLUDED."Rating";