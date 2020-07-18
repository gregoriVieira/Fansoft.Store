

Use master;
ALTER database [storedb] set offline with ROLLBACK IMMEDIATE;
DROP database [storedb];