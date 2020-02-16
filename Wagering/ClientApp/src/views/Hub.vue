<template>
  <div class="hero-body is-block">
    <div class="container">
      <article class="media">
        <div class="media-content">
          <div class="content">
            <h2 class="title has-text-centered">Fortnite</h2>
            <div class="columns is-mobile is-centered">
              <div class="column is-narrow">
                <div class="card">
                  <div class="card-content">
                    <figure class="image is-128x128">
                      <img src="@/assets/icons/coins.svg" />
                    </figure>
                  </div>
                  <footer class="card-footer">
                    <div class="card-footer-item">Wagers</div>
                    <router-link
                      :to="{ name: 'wagers', params: { game: 'fortnite' }}"
                      class="card-footer-item is-button"
                    >Enter</router-link>
                  </footer>
                </div>
              </div>
              <div class="column is-narrow">
                <div class="card">
                  <div class="card-content">
                    <figure class="image is-128x128">
                      <img src="@/assets/icons/trophy.svg" />
                    </figure>
                  </div>
                  <footer class="card-footer">
                    <div class="card-footer-item">Tournaments</div>
                    <router-link
                      :to="{ name: 'tournaments', params: { game: 'fortnite' }}"
                      class="card-footer-item is-button"
                    >Enter</router-link>
                  </footer>
                </div>
              </div>
            </div>
          </div>
        </div>
      </article>
    </div>
  </div>
</template> 
<script>
export default {};
</script>
<style scoped>
a.card-footer-item.is-button {
  color: white;
}
</style>