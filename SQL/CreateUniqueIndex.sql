-- Убедитесь, что существует уникальный индекс на (UserId, MovieId)
-- Если его нет, создайте:
CREATE UNIQUE INDEX idx_rate_userid_movieid ON "rate" ("UserId", "MovieId");