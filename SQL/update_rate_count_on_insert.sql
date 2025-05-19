CREATE OR REPLACE FUNCTION update_rate_count_on_insert()
RETURNS TRIGGER AS $$
BEGIN
    -- Увеличиваем RateCount в таблице movie на 1
    UPDATE "movie"
    SET "RateCount" = "RateCount" + 1
    WHERE "Id" = NEW."MovieId";

    RETURN NEW;
END;
$$ LANGUAGE plpgsql;