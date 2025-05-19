-- wwwroot/sql/RateMovie.sql
INSERT INTO "rate" ("UserId", "MovieId", "Rating")
VALUES ({0}, {1}, {2})
ON CONFLICT ("UserId", "MovieId") DO UPDATE SET
    "Rating" = EXCLUDED."Rating",