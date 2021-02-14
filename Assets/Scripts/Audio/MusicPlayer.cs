using UnityEngine;
using DG.Tweening;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource initialMusic;
    [SerializeField] private AudioSource gameMusic;
    [SerializeField] private AudioSource endingMusic;

    public void PlayGameMusic()
    {
        Sequence playGameMusicSeq = DOTween.Sequence();

        playGameMusicSeq.Append(initialMusic.DOFade(0, 3));

        playGameMusicSeq.InsertCallback(1, () => gameMusic.Play());
        playGameMusicSeq.Insert(1, gameMusic.DOFade(1, 3));

        playGameMusicSeq.Play();
    }

    public void PlayEndingMusic()
    {
        Sequence playEndingMusic = DOTween.Sequence();

        playEndingMusic.Append(gameMusic.DOFade(0, 3));

        playEndingMusic.InsertCallback(1, () => endingMusic.Play());
        playEndingMusic.Insert(1, endingMusic.DOFade(1, 3));

        playEndingMusic.Play();
    }
}
