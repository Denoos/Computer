﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Computer
{
    internal class DataBase
    {
        public DataBase()
        {
            GetFullData();
        }

        private async void GetFullData()
        {
            await Task.Delay(1000);
            singers = await GetAllSingers();
            musics = await GetAllMusics();
        }

        private List<Singer> singers = new();
        private List<Music> musics = new();

        public async Task<List<Singer>> GetFullSingerDataBase()
        { 
            await Task.Delay(100);
            
            return new List<Singer>()
            {
                new Singer { ID = 0, IsBoy = true, Name = "Максим Галкин", Musics = await GetFullMusicDataBase() },
                new Singer { ID = 1, IsBoy = false, Name = "Алла Пугачева", Musics = await GetFullMusicDataBase() },
                new Singer { ID = 2, IsBoy = false, Name = "Агата Кристи", Musics = await GetFullMusicDataBase() } 
            };
        }
        public async Task<List<Music>> GetFullMusicDataBase()
        {
            await Task.Delay(100);

            return new List<Music>()
            {
                new Music { ID = 0, Title = "Ляляля", Description = "Первая песенка певца"},
                new Music { ID = 1, Title = "Лелеле", Description = "Вторая песенка певца"},
                new Music { ID = 0, Title = "Лололо", Description = "Третья песенка певца"}
            };
        }


        public async Task AddMusic(Music music)
        {
            await Task.Delay(1000);

            if (musics.Count == 0)
            {
                music.ID = 0;
                musics.Add(music);
            }
            else
            {
                music.ID = musics[^1].ID + 1;
                musics.Add(music);
            }

        }
        public async Task AddSinger(Singer singer)
        {
            await Task.Delay(1000);

            if (singers.Count == 0)
                singer.ID = 0;
            else
                singer.ID = singers[^1].ID + 1;

            singers.Add(singer);
        }

        public async Task DeleteSinger(Singer singer)
        {
            await Task.Delay(1000);

            foreach (var m in singer.Musics)
                DeleteMusic(m);

            singers.Remove(singer);
        }

        public async Task DeleteMusic(Music music)
        {
            await Task.Delay(1000);

            musics.Remove(music);
        }

        public async Task<Singer> SearchSingerById(int id)
        {
            await Task.Delay(1000);

            foreach (var s in singers)
                if (s.ID == id)
                { 
                    var singer = s;
                    return singer;
                }

            return new Singer();
        }

        public async Task<Music> SearchMusicById(int id)
        {
            await Task.Delay(1000);

            foreach (var m in musics)
                if (m.ID == id)
                {
                    var music = m;
                    return music;
                }

            return new Music();
        }

        public async Task<List<Singer>> GetAllSingers()
        {
            await Task.Delay(1000);
            return new List<Singer>( await GetFullSingerDataBase());
        }

        public async Task<List<Music>> GetAllMusics()
        {
            await Task.Delay(1000);
            return new List<Music>(musics);
        }

        public async Task EditSinger(Singer singer)
        {
            await Task.Delay(1000);

            Singer s = await SearchSingerById(singer.ID);

            singers[s.ID] = s;
        }
        
        public async Task EditMusic(Music music)
        {
            await Task.Delay(1000);

            Music m = await SearchMusicById(music.ID);

            musics[m.ID] = m;
        }
    }
}